using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Entity
{
    public class FAFinance_Entity
    {
        public FAFinance_Entity()
        {
        }
        public List<MaintenanceCostbyOffice> MaintenanceCostbyOfficeList { get; set; }
        public List<AssetAcquisitionOfficeWise> AssetAcquisitionOfficeWiseList { get; set; }
        public List<LandValuebyOffice> LandValuebyOfficeList { get; set; }
        public List<BookValuevsAccumulatedPrice> BookValuevsAccumulatedPriceList { get; set; }
        public List<AssetDisposedAssetWise> AssetDisposedAssetWiseList { get; set; }
        public List<AssetDisposedOfficeWise> AssetDisposedOfficeWiseList { get; set; }
        public List<AssetAcquisitionAssetWise> AssetAcquisitionAssetWiseList { get; set; }
        public List<MaintenanceCostbyMonth> MaintenanceCostbyMonthList { get; set; }
        public List<BookValuebyAssetType> BookValuebyAssetTypeList { get; set; }
        public List<AcquisitionVsBookValue> AcquisitionVsBookValueList { get; set; }
    }
    public class MaintenanceCostbyOffice
    {
        public string OfficeName { get; set; }
        public long Transformer { get; set; }
        public long Vehicle { get; set; }
        public long OfficeEuqipment { get; set; }
        public long Building { get; set; }
        public long CivilWorks { get; set; }
        public int SequenceNo { get; set; }
    }
    public class AssetAcquisitionOfficeWise
    {
        public string OfficeName { get; set; }
        public long AcquisitionAmount { get; set; }
        public int SequenceNo { get; set; }
    }
    public class LandValuebyOffice
    {
        public string OfficeName { get; set; }
        public long LandValue { get; set; }
        public int SequenceNo { get; set; }
    }
    public class BookValuevsAccumulatedPrice
    {
        public string AssetSubType { get; set; }
        public double BookValue { get; set; }
        public double AccumulatedDepreciation { get; set; }
        public int SequenceNo { get; set; }
    }
    public class AssetDisposedAssetWise
    {
        public string AssetType { get; set; }
        public long SoldAmount { get; set; }
        public int SequenceNo { get; set; }
    }
    public class AssetDisposedOfficeWise
    {
        public string OfficeName { get; set; }
        public long SoldAmount { get; set; }
        public int SequenceNo { get; set; }
    }
    public class AssetAcquisitionAssetWise
    {
        public string AssetType { get; set; }
        public long AcquisitionAmount { get; set; }
        public int SequenceNo { get; set; }
    }
    public class MaintenanceCostbyMonth
    {
        public string Month { get; set; }
        public long MaintenanceCost { get; set; }
        public int SequenceNo { get; set; }
    }
    public class BookValuebyAssetType
    {
        public string AssetType { get; set; }
        public double BookValue { get; set; }
    }
    public class AcquisitionVsBookValue
    {
        public string AssetType { get; set; }
        public double BookValue { get; set; }
        public double Acquisition { get; set; }
        public string Organization { get; set; }
    }
}
