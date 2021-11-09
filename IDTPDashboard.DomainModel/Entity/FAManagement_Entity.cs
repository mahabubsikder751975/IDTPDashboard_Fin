using System;
using System.Collections.Generic;
using System.Text;

namespace IDTPDashboard.DomainModel.Entity
{
    public class FAManagement_Entity
    {
        public FAManagement_Entity()
        {
        }
        public List<InsuredNonInsuredAsset> InsuredNonInsuredAssetsList { get; set; }
        public List<ServiceLifeAnalysis> ServiceLifeAnalysesList { get; set; }
        public List<OperationalNonOperationalTransformer> OperationalNonOperationalTransformerList { get; set; }
        public List<LandUsagesbyOffice> LandUsagesbyOfficeList { get; set; }
        public List<TransformerOperationalAnalysisbyOffice> TransformerOperationalAnalysisbyOfficeList { get; set; }
        public List<TransformerOperationalAnalysisbyMonth> TransformerOperationalAnalysisbyMonthList { get; set; }
        public List<LandAreabyOffice> LandAreabyOfficeList { get; set; }
        public List<LandEncroachmentRatio> LandEncroachmentRatioList { get; set; }
        public List<SubStationsbyOffice> SubStationsbyOfficeList { get; set; }
        public List<TotalLandArea> TotalLandAreaList { get; set; }
        public List<UtilitywiseTotalLand> UtilitywiseTotalLandList { get; set; }
        public List<TotalLandbyUsages> TotalLandbyUsagesList { get; set; }
        public List<UtilitywiseTotalBuilding> UtilitywiseTotalBuildingList { get; set; }
        public List<TotalNumberofPowerPlant> TotalNumberofPowerPlantList { get; set; }
        public List<UtilitywiseTotalNumberofPowerPlant> UtilitywiseTotalNumberofPowerPlantList { get; set; }
        public List<UtilitywiseTotalNumberofPowerPlantinOperation> UtilitywiseTotalNumberofPowerPlantinOperationList { get; set; }
        public List<UtilitywiseTotalNumberofPowerPlantUnderMaintenance> UtilitywiseTotalNumberofPowerPlantUnderMaintenanceList { get; set; }
        public List<TotalInstalledCapacityofPowerPlant> TotalInstalledCapacityofPowerPlantList { get; set; }
       
        public List<UtilitywiseTotalInstalledCapacityofPowerPlant> UtilitywiseTotalInstalledCapacityofPowerPlantList { get; set; }
        public List<UtilitywiseTotalInstalledCapacityofPowerPlantinOperation> UtilitywiseTotalInstalledCapacityofPowerPlantinOperationList { get; set; }
        public List<UtilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenance> UtilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenanceList { get; set; }
        public List<FuelWisePowerPlant> FuelWisePowerPlantList { get; set; }
        public List<PPTypeWisePowerPlant> PPTypeWisePowerPlantList { get; set; }
        public List<TotalDistributionSubStations> TotalDistributionSubStationsList { get; set; }
        public List<UsagesWiseLandByOrg> UsagesWiseLandByOrgList { get; set; }
        public List<OrgWiseLandByUsages> OrgWiseLandByUsagesList { get; set; }
        public List<FuleWiswPPByOrg> FuleWiswPPByOrgList { get; set; }
    }

    public class InsuredNonInsuredAsset
    {
        public string AssetType { get; set; }
        public long Insured { get; set; }
        public long NonInsured { get; set; }
        public int SequenceNo { get; set; }
    }
    public class ServiceLifeAnalysis
    {
        public string OfficeName { get; set; }
        public long Transformer { get; set; }
        public long SubStation { get; set; }
        public long PowerTransformer { get; set; }
        public long CircuitBreaker { get; set; }
        public long Machinery { get; set; }
        public long Vehicle { get; set; }
        public int SequenceNo { get; set; }
    }
    public class OperationalNonOperationalTransformer
    {
        public string OfficeName { get; set; }
        public long Operational { get; set; }
        public long NonOperational { get; set; }
        public int SequenceNo { get; set; }
    }
    public class LandUsagesbyOffice
    {
        public string OfficeName { get; set; }
        public double PowerPlant { get; set; }
        public double SubStation { get; set; }
        public double OfficeBuilding { get; set; }
        public double ResidentialBuilding { get; set; }
        public double Road { get; set; }
        public double UndevelopedLand { get; set; }
        public double Others { get; set; }
        public int SequenceNo { get; set; }
    }
    public class TransformerOperationalAnalysisbyOffice
    {
        public string OfficeName { get; set; }
        public long Overloaded { get; set; }
        public long Burnt { get; set; }
        public int SequenceNo { get; set; }
    }
    public class TransformerOperationalAnalysisbyMonth
    {
        public string Month { get; set; }
        public long Overloaded { get; set; }
        public long Burnt { get; set; }
        public int SequenceNo { get; set; }
    }
    public class LandAreabyOffice
    {
        public string OfficeName { get; set; }
        public long TotalAreaOfLand { get; set; }
        public int SequenceNo { get; set; }
    }
    public class LandEncroachmentRatio
    {
        public long Encroachment { get; set; }
        public long PhysicalPossession { get; set; }
    }
    public class SubStationsbyOffice
    {
        public string OfficeName { get; set; }
        public long TotalSubStation { get; set; }
        public int SequenceNo { get; set; }
    }
    public class TotalLandArea
    {
        public long TotalArea { get; set; }
    }
    public class UtilitywiseTotalLand
    {
        public string Organization { get; set; }
        public long TotalArea { get; set; }
    }
    public class TotalLandbyUsages
    {
        public string Usages { get; set; }
        public long TotalArea { get; set; }
        public int SequenceNo { get; set; }
    }
    public class UtilitywiseTotalBuilding
    {
        public string Organization { get; set; }
        public long TotalArea { get; set; }
    }
    public class TotalNumberofPowerPlant
    {
        public long TotalPowerPlant { get; set; }
    }
    public class UtilitywiseTotalNumberofPowerPlant
    {
        public string Organization { get; set; }
        public long TotalPowerPlant { get; set; }
    }
    public class UtilitywiseTotalNumberofPowerPlantinOperation
    {
        public string Organization { get; set; }
        public long TotalPowerPlant { get; set; }
    }
    public class UtilitywiseTotalNumberofPowerPlantUnderMaintenance
    {
        public string Organization { get; set; }
        public long TotalPowerPlant { get; set; }
    }
    public class TotalInstalledCapacityofPowerPlant
    {
        public long TotalCapacity { get; set; }
    }
    public class UtilitywiseTotalInstalledCapacityofPowerPlant
    {
        public string Organization { get; set; }
        public long TotalCapacity { get; set; }
    }
    public class UtilitywiseTotalInstalledCapacityofPowerPlantinOperation
    {
        public string Organization { get; set; }
        public long TotalCapacity { get; set; }
    }
    public class UtilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenance
    {
        public string Organization { get; set; }
        public long TotalCapacity { get; set; }
    }

    public class FuelWisePowerPlant
    {
        public string FuelType { get; set; }
        public long TotalPowerPlant { get; set; }
    }
    public class PPTypeWisePowerPlant
    {
        public string PowerPlantType { get; set; }
        public long TotalPowerPlant { get; set; }
    }
    public class TotalDistributionSubStations
    {
        public long TotalDistributionSS { get; set; }
    }

    public class UsagesWiseLandByOrg
    {
        public string Usages { get; set; }
        public long TotalArea { get; set; }
    }

    public class OrgWiseLandByUsages
    {
        public string Organization { get; set; }
        public long TotalArea { get; set; }
    }

    public class FuleWiswPPByOrg
    {
        public string FuelType { get; set; }
        public long TotalPowerPlant { get; set; }
    }
}
