using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Configurations;

public partial class RoadSideOrderConfiguration : IEntityTypeConfiguration<RoadSideOrder>
{
    public void Configure(EntityTypeBuilder<RoadSideOrder> entity)
    {
        entity.Property(e => e.RoadSideOrderId).HasComment("ID");
        entity.Property(e => e.Amount)
            .HasComment("繳費單金額")
            .HasColumnType("decimal(18, 0)");
        entity.Property(e => e.BarCode)
            .HasMaxLength(100)
            .HasComment("條碼資料");
        entity.Property(e => e.CarColor)
            .HasMaxLength(30)
            .HasComment("車輛顏色");
        entity.Property(e => e.CarNo)
            .HasMaxLength(30)
            .HasComment("車號");
        entity.Property(e => e.CarType).HasComment("車輛類型\r\n1: 汽車\r\n2: 機車\r\n3: 貨車");
        entity.Property(e => e.ChargesType).HasComment("設備類型\r\n10:路邊PDA\r\n11:路邊車辨柱");
        entity.Property(e => e.ExtNo)
            .HasMaxLength(100)
            .HasComment("外部單號");
        entity.Property(e => e.GUID).HasComment("唯一編碼");
        entity.Property(e => e.HighLevel).HasComment("優先層級\r\n1開始,由小到大,代表車辨柱辨識圖片的優先層級");
        entity.Property(e => e.InsertTime)
            .HasComment("開單時間")
            .HasColumnType("datetime");
        entity.Property(e => e.InsertUserInfoId).HasComment("開單人員ID");
        entity.Property(e => e.IsAutoPayment).HasComment("自動代繳\r\n0:否\r\n1:是");
        entity.Property(e => e.MachineInfoId).HasComment("機台ID");
        entity.Property(e => e.PayDate)
            .HasComment("繳費時間")
            .HasColumnType("datetime");
        entity.Property(e => e.PayDeadLine)
            .HasComment("繳費截止日期")
            .HasColumnType("date");
        entity.Property(e => e.PayState).HasComment("繳費狀態\r\n0:未繳費\r\n1:無須繳費/已繳費\r\n2:免費");
        entity.Property(e => e.RateDetailId).HasComment("計算費率ID");
        entity.Property(e => e.RoadGridNo)
            .HasMaxLength(10)
            .HasComment("車格號碼");
        entity.Property(e => e.RoadSectionId).HasComment("路段ID");
        entity.Property(e => e.SiteInfoId).HasComment("場地ID");
        entity.Property(e => e.State).HasComment("狀態\r\n1:正常\r\n3:作廢\r\n9:刪除\r\n10:待辨識\r\n");
        entity.Property(e => e.TempCarNo)
            .HasMaxLength(30)
            .HasComment("車辨柱用,判斷是否為新開");
        entity.Property(e => e.TempOpenTime)
            .HasComment("暫存開單時間")
            .HasColumnType("datetime");
        entity.Property(e => e.TransactionType).HasComment("交易類型\r\n1:自營\r\n2:代開");
        entity.Property(e => e.UpdateTime)
            .HasComment("更新時間")
            .HasColumnType("datetime");
        entity.Property(e => e.UploadDate)
            .HasComment("上傳時間")
            .HasColumnType("datetime");
        entity.Property(e => e.UploadState).HasComment("上傳狀態\r\n0:未上傳\r\n1:已匯總上傳 (每日匯總)\r\n2:資料異常未上傳\r\n3:已開單上傳 (智慧柱即時)\r\n4:已結單上傳 (智慧柱即時)");
        entity.Property(e => e.VoidReason)
            .HasMaxLength(10)
            .HasComment("廢單原因\r\n1: 車號錯誤\r\n2: 路段錯誤\r\n3: 車格錯誤\r\n4: 車種錯誤\r\n5: 未按SOP作業誤開\r\n6: 重複開單\r\nG: 誤開身障單\r\nO: 其他");
        entity.Property(e => e.VoidTime)
            .HasComment("廢單時間")
            .HasColumnType("datetime");
        entity.Property(e => e.VoidUserInfoId).HasComment("廢單人員ID");

        entity.HasOne(d => d.RoadSection).WithMany(p => p.RoadSideOrder)
            .HasForeignKey(d => d.RoadSectionId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_RoadSideOrder_RoadSection");

        entity.HasOne(d => d.SiteInfo).WithMany(p => p.RoadSideOrder)
            .HasForeignKey(d => d.SiteInfoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_RoadSideOrder_Site");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<RoadSideOrder> modelBuilder);
}
