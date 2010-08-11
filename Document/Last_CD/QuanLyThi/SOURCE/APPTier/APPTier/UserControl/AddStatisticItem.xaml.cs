using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SqlGenerator;
using System.Data.SqlClient;
using System.Data;
using StatHandlers;

namespace APPTier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AddStatisticItem : Window
    {
        List<string> m_SelectedTable;
        List<string> m_SelectedColumnNameForSELECT;
        List<string> m_TableVariableListForSELECT;
        List<string> m_AllColumn;
        List<string> m_Tables;
        string m_SortType;
        string m_SQL;
        List<Criteria> m_ListCriteria;

        public AddStatisticItem()
        {
            this.InitializeComponent();
            // Insert code required on object creation below this point.
            m_SelectedTable = new List<string>();
            m_SelectedColumnNameForSELECT = new List<string>();
            m_TableVariableListForSELECT = new List<string>();
            m_AllColumn = new List<string>();
            m_Tables = new List<string>();
            m_SortType = string.Empty;
            m_SQL = string.Empty;
            m_ListCriteria = new List<Criteria>();
        }

        private void btnPreview_Click(object sender, RoutedEventArgs e)
        {
            generateSQLStatement();

            int res = executeQuery();
            if (res == -1)
                MessageBox.Show("Kiểu dữ liệu chưa đúng hoặc thông tin chưa đầy đủ.");
        }

        private int executeQuery()
        {
            if (m_SQL != "")
            {
                try
                {
                    DataLayer.DAO.DataConnector dc = new DataLayer.DAO.DataConnector();
                    string conStr = dc.getQuyTrinhThiConnectionString();
                    SqlConnection con = new SqlConnection(conStr);
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(m_SQL, con);
                    DataSet source = new DataSet();
                    da.Fill(source);
                    listResult.ItemsSource = source.Tables[0].DefaultView;
                    return 0;
                }
                catch
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        private void updateDataSource()
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < m_SelectedTable.Count; i++)
            {
                DataTable temp = NameConverter.getColumnList(m_SelectedTable[i]);
                removeMatKhauAndSALTColumn(ref temp, "matKhau");
                removeMatKhauAndSALTColumn(ref temp, "SALT");
                removeMatKhauAndSALTColumn(ref temp, "workflowInstanceID");
                dt.Merge(temp);
            }
            cbxHaving.ClearValue(ComboBox.ItemsSourceProperty);
            grvSelect.ItemsSource = dt.DefaultView;
            List<string> tencot = new List<string>();
            m_AllColumn.Clear();
            m_Tables.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                tencot.Add(dt.Rows[i][0].ToString() + " - " + dt.Rows[i][1].ToString());
                m_AllColumn.Add(dt.Rows[i][0].ToString());
                m_Tables.Add(NameConverter.getTableVariableNameByCommonName(dt.Rows[i][1].ToString()));
            }
            cbxHaving.ItemsSource = tencot;
        }

        private static void removeMatKhauAndSALTColumn(ref DataTable temp, string keyword)
        {
            for (int j = 0; j < temp.Rows.Count; j++)
                if (temp.Rows[j][0].ToString() == keyword)
                    temp.Rows.RemoveAt(j);
        }

        private void getSelectedItemInGridCheckBox()
        {
            m_SelectedColumnNameForSELECT.Clear();
            m_TableVariableListForSELECT.Clear();
            System.Collections.IList selectedColumn = grvSelect.SelectedItems;
            if (selectedColumn.Count != 0)
            {
                foreach (DataRowView row in selectedColumn)
                {
                    m_SelectedColumnNameForSELECT.Add(row[0].ToString());
                    m_TableVariableListForSELECT.Add(NameConverter.getTableVariableNameByCommonName(row[1].ToString()));
                }
            }
        }

        private void cbxGroupBy_DropDownOpened(object sender, EventArgs e)
        {
            getSelectedItemInGridCheckBox();
            cbxOrder.ClearValue(ComboBox.ItemsSourceProperty);

            List<string> list = new List<string>();
            for (int i = 0; i < m_SelectedColumnNameForSELECT.Count; i++)
                list.Add(m_SelectedColumnNameForSELECT[i] + "-" + NameConverter.getCommonNameByTableVariableName(m_TableVariableListForSELECT[i]));
            cbxOrder.ItemsSource = list;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (tbxAddCriteria.Text == "")
            {
                MessageBox.Show("Vui lòng nhập tên tiêu chí.");
                return;
            }

            generateSQLStatement();
            int res = executeQuery();

            if (res == -1)
            {
                MessageBox.Show("Kiểu dữ liệu chưa đúng hoặc thông tin chưa đầy đủ. Tiêu chí chưa được lưu.");
                return;
            }

            string tenTieuChi = tbxAddCriteria.Text;
            StatXMLParser p = new StatXMLParser("Stat.xml");
            p.Parse();

            StatHandlers.Type t = new StatHandlers.Type();
            t.Method = "custom";
            t.Name = "Bảng";
            t.SQL = m_SQL;

            Criteria c = new Criteria();
            c.Name = tenTieuChi;
            c.IsDetail = false;
            List<StatHandlers.Type> typee = new List<StatHandlers.Type>();
            typee.Add(t);
            c.TypeList = typee;

            StatHandlers.Object obj = p.getCustomObject();

            if (obj == null)
            {
                StatHandlers.Object o = new StatHandlers.Object();
                o.Name = "Custom";
                o.CriteriaList.Add(c);

                p.ObjectList.Add(o);
            }
            else
            {
                obj.CriteriaList.Add(c);
            }

            p.Save("Stat.xml");
            MessageBox.Show("Bạn đã thêm tiêu chí thành công.");
            resetAllValue();
        }

        private void resetAllValue()
        {
            cbCV.IsChecked = false;
            cbCC.IsChecked = false;
            cbDTCC.IsChecked = false;
            cbGC.IsChecked = false;
            cbNVTH.IsChecked = false;
            cbPC.IsChecked = false;
            cbQL.IsChecked = false;
            cbTD.IsChecked = false;
            cbTB.IsChecked = false;
            cbDT.IsChecked = false;
            cbxPhanNhom.IsChecked = false;
            tbxAddCriteria.Text = "";
            grvSelect.ItemsSource = new DataTable().DefaultView;
        }
        /// <summary>
        /// tạo chuỗi SQL tự động
        /// </summary>
        /// <returns></returns>
        private void generateSQLStatement()
        {
            m_SQL = string.Empty;
            #region SELECT
            string selectString = string.Empty;
            getSelectedItemInGridCheckBox();
            if (m_SelectedColumnNameForSELECT.Count != 0)
            {
                Select selectStatement = new Select(m_SelectedColumnNameForSELECT, m_TableVariableListForSELECT);
                selectString = selectStatement.generateSelect();
                m_SQL += selectString;
                if (m_SQL == "Select ")
                    return;
            }
            else
                return;
            #endregion

            #region FROM
            string fromStatement = new From(m_SelectedTable).generateStatement();
            m_SQL += fromStatement;
            #endregion

            #region WHERE
            List<string> cotWhere = new List<string>();
            List<string> valueWhere = new List<string>();
            #region get value for WHERE
            if (tbxCV1.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxCV1.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxCV1.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxCV1.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxCV1.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxCV2.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxCV2.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxCV2.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxCV2.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxCV2.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxCV3.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxCV3.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxCV3.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxCV3.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxCV3.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxCV4.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxCV4.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxCV4.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxCV4.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxCV4.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxCV5.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxCV5.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxCV5.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxCV5.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxCV5.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxCC1.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxCC1.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxCC1.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxCC1.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxCC1.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxCC2.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxCC2.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxCC2.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxCC2.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxCC2.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxDT1.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxDT1.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxDT1.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxDT1.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxDT1.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxDT2.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxDT2.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxDT2.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxDT2.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxDT2.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxDT3.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxDT3.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxDT3.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxDT3.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxDT3.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxDT4.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxDT4.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxDT4.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxDT4.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxDT4.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxDTCC1.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxDTCC1.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxDTCC1.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxDTCC1.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxDTCC1.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxDTCC2.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxDTCC2.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxDTCC2.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxDTCC2.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxDTCC2.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxDTCC3.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxDTCC3.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxDTCC3.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxDTCC3.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxDTCC3.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxGC1.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxGC1.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxGC1.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxGC1.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxGC1.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxGC2.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxGC2.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxGC2.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxGC2.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxGC2.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxGC3.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxGC3.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxGC3.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxGC3.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxGC3.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxNVTH1.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxNVTH1.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxNVTH1.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxNVTH1.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxNVTH1.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxNVTH2.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxNVTH2.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxNVTH2.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxNVTH2.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxNVTH2.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxNVTH3.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxNVTH3.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxNVTH3.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxNVTH3.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxNVTH3.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxNVTH4.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxNVTH4.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxNVTH4.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxNVTH4.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxNVTH4.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxNVTH5.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxNVTH5.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxNVTH5.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxNVTH5.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxNVTH5.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxPC1.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxPC1.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxPC1.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxPC1.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxPC1.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxPC2.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxPC2.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxPC2.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxPC2.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxPC2.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxPC3.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxPC3.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxPC3.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxPC3.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxPC3.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxPC4.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxPC4.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxPC4.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxPC4.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxPC4.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxQL1.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxQL1.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxQL1.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxQL1.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxQL1.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxQL2.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxQL2.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxQL2.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxQL2.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxQL2.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxTB1.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxTB1.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxTB1.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxTB1.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxTB1.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxTB2.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxTB2.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxTB2.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxTB2.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxTB2.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxTB3.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxTB3.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxTB3.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxTB3.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxTB3.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxTB4.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxTB4.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxTB4.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxTB4.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxTB4.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxTD1.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxTD1.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxTD1.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxTD1.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxTD1.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxTD2.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxTD2.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxTD2.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxTD2.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxTD2.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxTD3.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxTD3.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxTD3.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxTD3.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxTD3.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxTD4.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxTD4.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxTD4.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxTD4.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxTD4.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxTD5.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxTD5.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxTD5.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxTD5.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxTD5.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxTD6.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxTD6.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxTD6.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxTD6.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxTD6.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxTD7.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxTD7.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxTD7.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxTD7.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxTD7.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxTD8.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxTD8.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxTD8.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxTD8.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxTD8.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxTD9.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxTD9.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxTD9.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxTD9.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxTD9.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            if (tbxTD10.Text != "")
            {
                cotWhere.Add(NameConverter.convertColumnName(cbxTD10.Text));
                KeyValuePair<string, string> pairTableVariable = NameConverter.getTableByUIControlName(cbxTD10.Name);
                string datatype = NameConverter.getColumnType(NameConverter.convertColumnName(cbxTD10.Text), pairTableVariable.Key).ToString();
                valueWhere.Add(datatype);
                valueWhere.Add(tbxTD10.Text);
                valueWhere.Add(pairTableVariable.Value);
            }
            #endregion
            string whereStatement = new Where(cotWhere, valueWhere).generateStatement();
            m_SQL += whereStatement;
            #endregion

            #region GROUPBY-HAVING-ORDERBY
            if (cbxPhanNhom.IsChecked == true)
            {
                #region GROUP BY
                GroupBy gb = new GroupBy(m_AllColumn, m_Tables);
                m_SQL += gb.generateStatement();
                #endregion

                #region HAVING
                if (tbxHaving.Text != "")
                {
                    string cot = m_AllColumn[cbxHaving.SelectedIndex];
                    string table = m_Tables[cbxHaving.SelectedIndex];
                    List<string> input1 = new List<string>();
                    input1.Add(table);
                    input1.Add(cot);

                    string datatype = NameConverter.getColumnType(cot, NameConverter.getDatabaseNameByTableVariableName(table)).ToString();
                    List<string> input2 = new List<string>();
                    input2.Add(datatype);
                    input2.Add(tbxHaving.Text);
                    Having x = new Having(input1, input2);
                    m_SQL += x.generateStatement();
                }
                #endregion

                #region ORDER BY
                List<string> orderByData = new List<string>();
                if (cbxOrder.SelectedIndex != -1)
                {
                    int idx = cbxOrder.SelectedIndex;
                    orderByData.Add(m_TableVariableListForSELECT[idx]);
                    orderByData.Add(m_SelectedColumnNameForSELECT[idx]);
                    orderByData.Add(m_SortType);
                    OrderBy ob = new OrderBy(orderByData);
                    m_SQL += ob.generateStatement();
                }
                #endregion
            }
            #endregion
        }

        #region UI Handlers
        private void Grid_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Add event handler implementation here.

        }

        private void Border_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Add event handler implementation here.
            this.DragMove();
        }

        private void btnMinimize_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Add event handler implementation here.
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // TODO: Add event handler implementation here.
            //MessageBoxResult msg = MessageBox.Show("Bạn thật sự muốn thoát khỏi chương trình?", "Thoát", MessageBoxButton.YesNo);
            //if (msg == MessageBoxResult.Yes)
            //{
                this.Close();
            //}
        }

        private void btnAdd6_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridCV2.Visibility = Visibility.Visible;
        }

        private void btnAdd1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridCV3.Visibility = Visibility.Visible;
        }

        private void btnAdd2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridCV4.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnAdd3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridCV5.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnAdd4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridCC2.Visibility = Visibility.Visible;
        }

        private void btnAdd5_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridDT2.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnAdd7_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridDT3.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnAdd8_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridDT4.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnDTCC1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridDTCC2.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnDTCC2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridDTCC3.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnGC1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridGC2.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnGC2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridGC3.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnNVTH1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridNVTH2.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnNVTH2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridNVTH3.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnNVTH3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridNVTH4.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnNVTH4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridNVTH5.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }


        private void btnPC1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridPC2.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnPC2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridPC3.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnPC3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridPC4.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnQL1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridQL2.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnTB1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridTB2.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.

        }

        private void btnTB2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridTB3.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnTB3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridTB4.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnTD1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridTD2.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.

        }

        private void btnTD2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridTD3.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnTD3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridTD4.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnTD4_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridTD5.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.

        }

        private void btnTD5_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridTD6.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnTD6_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridTD7.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnTD7_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridTD8.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnTD8_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridTD9.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void btnTD9_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.GridTD10.Visibility = Visibility.Visible;// TODO: Add event handler implementation here.
        }

        private void cbCV_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Add(NameConverter.convertTable(cbCV.Content.ToString()).Key);
            this.bdrCV.Visibility = Visibility.Visible;
            updateDataSource();
        }

        private void cbCV_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Remove(NameConverter.convertTable(cbCV.Content.ToString()).Key);
            this.bdrCV.Visibility = Visibility.Collapsed;
            tbxCV1.Text = "";
            tbxCV2.Text = "";
            tbxCV3.Text = "";
            tbxCV4.Text = "";
            tbxCV5.Text = "";
            updateDataSource();
            GridCV2.Visibility = Visibility.Collapsed;
            GridCV3.Visibility = Visibility.Collapsed;
            GridCV4.Visibility = Visibility.Collapsed;
            GridCV5.Visibility = Visibility.Collapsed;
        }

        private void cbCC_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Add(NameConverter.convertTable(cbCC.Content.ToString()).Key);
            this.bdrCC.Visibility = Visibility.Visible;
            updateDataSource();
        }

        private void cbCC_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Remove(NameConverter.convertTable(cbCC.Content.ToString()).Key);
            this.bdrCC.Visibility = Visibility.Collapsed;
            tbxCC1.Text = "";
            tbxCC2.Text = "";
            updateDataSource();
            GridCC2.Visibility = Visibility.Collapsed;

        }

        private void cbDTCC_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Add(NameConverter.convertTable(cbDTCC.Content.ToString()).Key);
            this.bdrDTCC.Visibility = Visibility.Visible;
            updateDataSource();
        }

        private void cbDTCC_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Remove(NameConverter.convertTable(cbDTCC.Content.ToString()).Key);
            this.bdrDTCC.Visibility = Visibility.Collapsed;
            tbxDTCC1.Text = "";
            tbxDTCC2.Text = "";
            tbxDTCC3.Text = "";
            updateDataSource();
            GridDTCC2.Visibility = Visibility.Collapsed;
            GridDTCC3.Visibility = Visibility.Collapsed;

        }

        private void cbGC_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Add(NameConverter.convertTable(cbGC.Content.ToString()).Key);
            this.bdrGC.Visibility = Visibility.Visible;
            updateDataSource();
        }

        private void cbGC_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Remove(NameConverter.convertTable(cbGC.Content.ToString()).Key);

            this.bdrGC.Visibility = Visibility.Collapsed;
            tbxGC1.Text = "";
            tbxGC2.Text = "";
            tbxGC3.Text = "";
            updateDataSource();
            GridGC2.Visibility = Visibility.Collapsed;
            GridGC3.Visibility = Visibility.Collapsed;

        }

        private void cbTB_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Add(NameConverter.convertTable(cbTB.Content.ToString()).Key);
            this.bdrTB.Visibility = Visibility.Visible;
            updateDataSource();
        }

        private void cbTB_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Remove(NameConverter.convertTable(cbTB.Content.ToString()).Key);
            this.bdrTB.Visibility = Visibility.Collapsed;
            tbxTB1.Text = "";
            tbxTB2.Text = "";
            tbxTB3.Text = "";
            tbxTB4.Text = "";
            updateDataSource();
            GridTB2.Visibility = Visibility.Collapsed;
            GridTB3.Visibility = Visibility.Collapsed;
            GridTB4.Visibility = Visibility.Collapsed;

        }

        private void cbNVTH_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Add(NameConverter.convertTable(cbNVTH.Content.ToString()).Key);
            this.bdrNVTH.Visibility = Visibility.Visible;
            updateDataSource();
        }

        private void cbNVTH_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Remove(NameConverter.convertTable(cbNVTH.Content.ToString()).Key);
            this.bdrNVTH.Visibility = Visibility.Collapsed;
            tbxNVTH1.Text = "";
            tbxNVTH2.Text = "";
            tbxNVTH3.Text = "";
            tbxNVTH4.Text = "";
            tbxNVTH5.Text = "";
            updateDataSource();
            GridNVTH2.Visibility = Visibility.Collapsed;
            GridNVTH3.Visibility = Visibility.Collapsed;
            GridNVTH4.Visibility = Visibility.Collapsed;
            GridNVTH5.Visibility = Visibility.Collapsed;


        }

        private void cbPC_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Add(NameConverter.convertTable(cbPC.Content.ToString()).Key);
            this.bdrPC.Visibility = Visibility.Visible;
            updateDataSource();
        }

        private void cbPC_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Remove(NameConverter.convertTable(cbPC.Content.ToString()).Key);
            this.bdrPC.Visibility = Visibility.Collapsed;
            tbxPC1.Text = "";
            tbxPC2.Text = "";
            tbxPC3.Text = "";
            tbxPC4.Text = "";
            updateDataSource();
            GridPC2.Visibility = Visibility.Collapsed;
            GridPC3.Visibility = Visibility.Collapsed;
            GridPC4.Visibility = Visibility.Collapsed;

        }

        private void cbQL_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Add(NameConverter.convertTable(cbQL.Content.ToString()).Key);
            this.bdrQL.Visibility = Visibility.Visible;
            updateDataSource();
        }

        private void cbQL_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Remove(NameConverter.convertTable(cbQL.Content.ToString()).Key);
            this.bdrQL.Visibility = Visibility.Collapsed;
            tbxQL1.Text = "";
            tbxQL2.Text = "";
            updateDataSource();
            GridQL2.Visibility = Visibility.Collapsed;

        }

        private void cbTD_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Add(NameConverter.convertTable(cbTD.Content.ToString()).Key);
            this.bdrTD.Visibility = Visibility.Visible;
            updateDataSource();
        }

        private void cbTD_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Remove(NameConverter.convertTable(cbTD.Content.ToString()).Key);
            this.bdrTD.Visibility = Visibility.Collapsed;
            tbxTD1.Text = "";
            tbxTD2.Text = "";
            tbxTD3.Text = "";
            tbxTD4.Text = "";
            tbxTD5.Text = "";
            tbxTD6.Text = "";
            tbxTD7.Text = "";
            tbxTD8.Text = "";
            tbxTD9.Text = "";
            tbxTD10.Text = "";
            updateDataSource();
            GridTD2.Visibility = Visibility.Collapsed;
            GridTD3.Visibility = Visibility.Collapsed;
            GridTD4.Visibility = Visibility.Collapsed;
            GridTD5.Visibility = Visibility.Collapsed;
            GridTD6.Visibility = Visibility.Collapsed;
            GridTD7.Visibility = Visibility.Collapsed;
            GridTD8.Visibility = Visibility.Collapsed;
            GridTD9.Visibility = Visibility.Collapsed;
            GridTD10.Visibility = Visibility.Collapsed;

        }

        private void cbDT_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Add(NameConverter.convertTable(cbDT.Content.ToString()).Key);
            this.bdrDT.Visibility = Visibility.Visible;
            updateDataSource();
        }

        private void cbDT_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            m_SelectedTable.Remove(NameConverter.convertTable(cbDT.Content.ToString()).Key);
            this.bdrDT.Visibility = Visibility.Collapsed;
            tbxDT1.Text = "";
            tbxDT2.Text = "";
            tbxDT3.Text = "";
            tbxDT4.Text = "";
            updateDataSource();
            GridDT2.Visibility = Visibility.Collapsed;
            GridDT3.Visibility = Visibility.Collapsed;
            GridDT4.Visibility = Visibility.Collapsed;

        }
        #endregion

        #region CheckBoxOrderHaving
        private void cbxPhanNhom_Checked(object sender, System.Windows.RoutedEventArgs e)
        {

            tbxHaving.IsEnabled = true;
            cbxHaving.IsEnabled = true;
            cbxOrder.IsEnabled = true;
            cbxASC.IsEnabled = true;
            cbxDES.IsEnabled = true;
        }

        private void cbxPhanNhom_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {

            tbxHaving.IsEnabled = false;
            tbxHaving.Text = "";
            cbxHaving.IsEnabled = false;
            cbxHaving.SelectedIndex = -1;
            cbxOrder.IsEnabled = false;
            cbxOrder.SelectedIndex = -1;
            cbxASC.IsEnabled = false;
            cbxASC.IsChecked = false;
            cbxDES.IsEnabled = false;
            cbxDES.IsChecked = false;
        }

        private void cbxASC_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            cbxDES.IsChecked = false;
            m_SortType = "ASC";
        }

        private void cbxDES_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            cbxASC.IsChecked = false;
            m_SortType = "DESC";
        }
        #endregion
    }
}