
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Text;
using System.Data.SqlClient;
using System.IO;

namespace DataLayer.DAO
{
    public class DataConnector
    {
        private string m_strServerName;
        private string m_strDatabaseName;
        private string m_strUserID;
        private string m_strPass;

        public DataConnector()
        {
            m_strServerName = "DHA-PC\\SQLEXPRESS";
            m_strDatabaseName = "QuyTrinhThiDB";
            m_strUserID = " ";
            m_strPass = " ";
            WriteBinary("dbinfo.dat");
        }

        public string strServerName
        {
            get { return m_strServerName; }
            set { m_strServerName = value; }
        }

        public string strDatabaseName
        {
            get { return m_strDatabaseName; }
            set { m_strDatabaseName = value; }
        }

        public string strUserID
        {
            get { return m_strUserID; }
            set { m_strUserID = value; }
        }

        public string strPass
        {
            get { return m_strPass; }
            set { m_strPass = value; }
        }

        public string getConnectionString()
        {
            ReadBinary("dbinfo.dat");
            return "Data Source=" + m_strServerName + ";Initial Catalog=" + m_strDatabaseName + ";Integrated Security=True;User ID=" + m_strUserID + ";Password=" + m_strPass;
        }

        public string WriteBinary(string fileName)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                using (BinaryWriter binWriter =
            new BinaryWriter(File.Open(fileName, FileMode.Create)))
                {
                    binWriter.Write(m_strServerName.Length);
                    binWriter.Write(Encoding.Default.GetBytes(m_strServerName));
                    binWriter.Write(m_strDatabaseName.Length);
                    binWriter.Write(Encoding.Default.GetBytes(m_strDatabaseName));
                    binWriter.Write(m_strUserID.Length);
                    binWriter.Write(Encoding.Default.GetBytes(m_strUserID));
                    binWriter.Write(m_strPass.Length);
                    binWriter.Write(Encoding.Default.GetBytes(m_strPass));
                }

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string ReadBinary(string fileName)
        {
            if (File.Exists(fileName))
            {
                BinaryReader binReader =
                    new BinaryReader(File.Open(fileName, FileMode.Open));
                try
                {
                    int temp;
                    // If the file is not empty, 
                    // read the application settings.
                    if (binReader.PeekChar() != -1)
                    {
                        temp = binReader.ReadInt32();
                        m_strServerName = Encoding.Default.GetString(binReader.ReadBytes(temp));
                        temp = binReader.ReadInt32();
                        m_strDatabaseName = Encoding.Default.GetString(binReader.ReadBytes(temp));
                        temp = binReader.ReadInt32();
                        m_strUserID = Encoding.Default.GetString(binReader.ReadBytes(temp));
                        temp = binReader.ReadInt32();
                        m_strPass = Encoding.Default.GetString(binReader.ReadBytes(temp));
                    }
                }

                // If the end of the stream is reached before reading
                // the four data values, ignore the error and use the
                // default settings for the remaining values.
                catch (EndOfStreamException e)
                {
                    return e.Message;
                }
                finally
                {
                    binReader.Close();

                }
            }

            return null;
        }

    }
}
