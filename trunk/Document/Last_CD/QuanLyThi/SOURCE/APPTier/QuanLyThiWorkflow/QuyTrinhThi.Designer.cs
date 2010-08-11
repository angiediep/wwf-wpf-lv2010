using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace QuanLyThiWorkflow
{
	partial class QuyTrinhThi
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            this.NhanDangKyPhucKhao = new QuanLyThiWorkflow.WorkItem();
            this.CongBoDiem = new QuanLyThiWorkflow.WorkItem();
            this.sequenceActivity11 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity10 = new System.Workflow.Activities.SequenceActivity();
            this.TrinhKy = new QuanLyThiWorkflow.WorkItem();
            this.LapCongVanMuaPhoi = new QuanLyThiWorkflow.WorkItem();
            this.LapDanhSachCapCC = new QuanLyThiWorkflow.WorkItem();
            this.CongBoKetQuaPhucKhao = new QuanLyThiWorkflow.WorkItem();
            this.ChamPhucKhao = new QuanLyThiWorkflow.WorkItem();
            this.parallelActivity4 = new System.Workflow.Activities.ParallelActivity();
            this.NopBangDiemGoc = new QuanLyThiWorkflow.WorkItem();
            this.KiemTraDiemThi = new QuanLyThiWorkflow.WorkItem();
            this.PhanCongChamThi = new QuanLyThiWorkflow.WorkItem();
            this.ChuanBiHoSoThi = new QuanLyThiWorkflow.WorkItem();
            this.ChuanBiDeThi = new QuanLyThiWorkflow.WorkItem();
            this.LapDanhSachThi = new QuanLyThiWorkflow.WorkItem();
            this.PhanCongCoiThi = new QuanLyThiWorkflow.WorkItem();
            this.NhanHoSo = new QuanLyThiWorkflow.WorkItem();
            this.sequenceActivity9 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity8 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity7 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity6 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity5 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity4 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity3 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity2 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.KyVaDongDau = new QuanLyThiWorkflow.WorkItem();
            this.InChungChi = new QuanLyThiWorkflow.WorkItem();
            this.ChoMuaPhoiCC = new QuanLyThiWorkflow.WorkItem();
            this.GuiCongVanRaBoGD = new QuanLyThiWorkflow.WorkItem();
            this.parallelActivity3 = new System.Workflow.Activities.ParallelActivity();
            this.parallelActivity2 = new System.Workflow.Activities.ParallelActivity();
            this.ChamThi = new QuanLyThiWorkflow.WorkItem();
            this.Thi = new QuanLyThiWorkflow.WorkItem();
            this.parallelActivity1 = new System.Workflow.Activities.ParallelActivity();
            // 
            // NhanDangKyPhucKhao
            // 
            this.NhanDangKyPhucKhao.Name = "NhanDangKyPhucKhao";
            // 
            // CongBoDiem
            // 
            this.CongBoDiem.Name = "CongBoDiem";
            // 
            // sequenceActivity11
            // 
            this.sequenceActivity11.Activities.Add(this.NhanDangKyPhucKhao);
            this.sequenceActivity11.Name = "sequenceActivity11";
            // 
            // sequenceActivity10
            // 
            this.sequenceActivity10.Activities.Add(this.CongBoDiem);
            this.sequenceActivity10.Name = "sequenceActivity10";
            // 
            // TrinhKy
            // 
            this.TrinhKy.Name = "TrinhKy";
            // 
            // LapCongVanMuaPhoi
            // 
            this.LapCongVanMuaPhoi.Name = "LapCongVanMuaPhoi";
            // 
            // LapDanhSachCapCC
            // 
            this.LapDanhSachCapCC.Name = "LapDanhSachCapCC";
            // 
            // CongBoKetQuaPhucKhao
            // 
            this.CongBoKetQuaPhucKhao.Name = "CongBoKetQuaPhucKhao";
            // 
            // ChamPhucKhao
            // 
            this.ChamPhucKhao.Name = "ChamPhucKhao";
            // 
            // parallelActivity4
            // 
            this.parallelActivity4.Activities.Add(this.sequenceActivity10);
            this.parallelActivity4.Activities.Add(this.sequenceActivity11);
            this.parallelActivity4.Name = "parallelActivity4";
            // 
            // NopBangDiemGoc
            // 
            this.NopBangDiemGoc.Name = "NopBangDiemGoc";
            // 
            // KiemTraDiemThi
            // 
            this.KiemTraDiemThi.Name = "KiemTraDiemThi";
            // 
            // PhanCongChamThi
            // 
            this.PhanCongChamThi.Name = "PhanCongChamThi";
            // 
            // ChuanBiHoSoThi
            // 
            this.ChuanBiHoSoThi.Name = "ChuanBiHoSoThi";
            // 
            // ChuanBiDeThi
            // 
            this.ChuanBiDeThi.Name = "ChuanBiDeThi";
            // 
            // LapDanhSachThi
            // 
            this.LapDanhSachThi.Name = "LapDanhSachThi";
            // 
            // PhanCongCoiThi
            // 
            this.PhanCongCoiThi.Name = "PhanCongCoiThi";
            // 
            // NhanHoSo
            // 
            this.NhanHoSo.Name = "NhanHoSo";
            // 
            // sequenceActivity9
            // 
            this.sequenceActivity9.Activities.Add(this.LapDanhSachCapCC);
            this.sequenceActivity9.Activities.Add(this.LapCongVanMuaPhoi);
            this.sequenceActivity9.Activities.Add(this.TrinhKy);
            this.sequenceActivity9.Name = "sequenceActivity9";
            // 
            // sequenceActivity8
            // 
            this.sequenceActivity8.Activities.Add(this.parallelActivity4);
            this.sequenceActivity8.Activities.Add(this.ChamPhucKhao);
            this.sequenceActivity8.Activities.Add(this.CongBoKetQuaPhucKhao);
            this.sequenceActivity8.Name = "sequenceActivity8";
            // 
            // sequenceActivity7
            // 
            this.sequenceActivity7.Activities.Add(this.NopBangDiemGoc);
            this.sequenceActivity7.Name = "sequenceActivity7";
            // 
            // sequenceActivity6
            // 
            this.sequenceActivity6.Activities.Add(this.KiemTraDiemThi);
            this.sequenceActivity6.Name = "sequenceActivity6";
            // 
            // sequenceActivity5
            // 
            this.sequenceActivity5.Activities.Add(this.PhanCongChamThi);
            this.sequenceActivity5.Name = "sequenceActivity5";
            // 
            // sequenceActivity4
            // 
            this.sequenceActivity4.Activities.Add(this.ChuanBiDeThi);
            this.sequenceActivity4.Activities.Add(this.ChuanBiHoSoThi);
            this.sequenceActivity4.Name = "sequenceActivity4";
            // 
            // sequenceActivity3
            // 
            this.sequenceActivity3.Activities.Add(this.LapDanhSachThi);
            this.sequenceActivity3.Name = "sequenceActivity3";
            // 
            // sequenceActivity2
            // 
            this.sequenceActivity2.Activities.Add(this.PhanCongCoiThi);
            this.sequenceActivity2.Name = "sequenceActivity2";
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.NhanHoSo);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // KyVaDongDau
            // 
            this.KyVaDongDau.Name = "KyVaDongDau";
            // 
            // InChungChi
            // 
            this.InChungChi.Name = "InChungChi";
            // 
            // ChoMuaPhoiCC
            // 
            this.ChoMuaPhoiCC.Name = "ChoMuaPhoiCC";
            // 
            // GuiCongVanRaBoGD
            // 
            this.GuiCongVanRaBoGD.Name = "GuiCongVanRaBoGD";
            // 
            // parallelActivity3
            // 
            this.parallelActivity3.Activities.Add(this.sequenceActivity8);
            this.parallelActivity3.Activities.Add(this.sequenceActivity9);
            this.parallelActivity3.Name = "parallelActivity3";
            // 
            // parallelActivity2
            // 
            this.parallelActivity2.Activities.Add(this.sequenceActivity6);
            this.parallelActivity2.Activities.Add(this.sequenceActivity7);
            this.parallelActivity2.Name = "parallelActivity2";
            // 
            // ChamThi
            // 
            this.ChamThi.Name = "ChamThi";
            // 
            // Thi
            // 
            this.Thi.Name = "Thi";
            // 
            // parallelActivity1
            // 
            this.parallelActivity1.Activities.Add(this.sequenceActivity1);
            this.parallelActivity1.Activities.Add(this.sequenceActivity2);
            this.parallelActivity1.Activities.Add(this.sequenceActivity3);
            this.parallelActivity1.Activities.Add(this.sequenceActivity4);
            this.parallelActivity1.Activities.Add(this.sequenceActivity5);
            this.parallelActivity1.Name = "parallelActivity1";
            // 
            // QuyTrinhThi
            // 
            this.Activities.Add(this.parallelActivity1);
            this.Activities.Add(this.Thi);
            this.Activities.Add(this.ChamThi);
            this.Activities.Add(this.parallelActivity2);
            this.Activities.Add(this.parallelActivity3);
            this.Activities.Add(this.GuiCongVanRaBoGD);
            this.Activities.Add(this.ChoMuaPhoiCC);
            this.Activities.Add(this.InChungChi);
            this.Activities.Add(this.KyVaDongDau);
            this.Name = "QuyTrinhThi";
            this.CanModifyActivities = false;

		}

		#endregion

        private WorkItem NopBangDiemGoc;
        private WorkItem KiemTraDiemThi;
        private WorkItem PhanCongChamThi;
        private WorkItem ChuanBiHoSoThi;
        private WorkItem ChuanBiDeThi;
        private WorkItem LapDanhSachThi;
        private WorkItem PhanCongCoiThi;
        private WorkItem NhanHoSo;
        private SequenceActivity sequenceActivity7;
        private SequenceActivity sequenceActivity6;
        private SequenceActivity sequenceActivity5;
        private SequenceActivity sequenceActivity4;
        private SequenceActivity sequenceActivity3;
        private SequenceActivity sequenceActivity2;
        private SequenceActivity sequenceActivity1;
        private ParallelActivity parallelActivity2;
        private WorkItem ChamThi;
        private WorkItem Thi;
        private WorkItem NhanDangKyPhucKhao;
        private WorkItem CongBoDiem;
        private SequenceActivity sequenceActivity11;
        private SequenceActivity sequenceActivity10;
        private WorkItem TrinhKy;
        private WorkItem LapCongVanMuaPhoi;
        private WorkItem LapDanhSachCapCC;
        private WorkItem CongBoKetQuaPhucKhao;
        private WorkItem ChamPhucKhao;
        private ParallelActivity parallelActivity4;
        private SequenceActivity sequenceActivity9;
        private SequenceActivity sequenceActivity8;
        private WorkItem KyVaDongDau;
        private WorkItem InChungChi;
        private WorkItem ChoMuaPhoiCC;
        private WorkItem GuiCongVanRaBoGD;
        private ParallelActivity parallelActivity3;
        private ParallelActivity parallelActivity1;




    }
}
