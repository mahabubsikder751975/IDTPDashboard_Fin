using IDTPDashboard.DataAccess.Interface;
using IDTPDashboard.DomainModel.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Repositoty 
{
    public class FAManagement_Repository : IFAManagement_Repository
    {
        private readonly string _connectionString;
        public FAManagement_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }

        public async Task<FAManagement_Entity> GetAllReports(string Organization)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("FAM_Dashboard", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Organization", Organization));

                    var response = new FAManagement_Entity();
                    var insuredNonInsuredAssetData = new List<InsuredNonInsuredAsset>();
                    var serviceLifeAnalysisData = new List<ServiceLifeAnalysis>();
                    var operationalNonOperationalTransformerData = new List<OperationalNonOperationalTransformer>();
                    var landUsagesbyOfficeData = new List<LandUsagesbyOffice>();
                    var transformerOperationalAnalysisbyOfficeData = new List<TransformerOperationalAnalysisbyOffice>();
                    var transformerOperationalAnalysisbyMonthData = new List<TransformerOperationalAnalysisbyMonth>();
                    var landAreabyOfficeData = new List<LandAreabyOffice>();
                    var landEncroachmentRatioData = new List<LandEncroachmentRatio>();
                    var subStationsbyOfficeData = new List<SubStationsbyOffice>();
                    var totalLandAreaData = new List<TotalLandArea>();
                    var utilitywiseTotalLandData = new List<UtilitywiseTotalLand>();
                    var totalLandbyUsagesData = new List<TotalLandbyUsages>();
                    var utilitywiseTotalBuildingData = new List<UtilitywiseTotalBuilding>();
                    var totalNumberofPowerPlantData = new List<TotalNumberofPowerPlant>();
                    var utilitywiseTotalNumberofPowerPlantData = new List<UtilitywiseTotalNumberofPowerPlant>();
                    var utilitywiseTotalNumberofPowerPlantinOperationData = new List<UtilitywiseTotalNumberofPowerPlantinOperation>();
                    var utilitywiseTotalNumberofPowerPlantUnderMaintenanceData = new List<UtilitywiseTotalNumberofPowerPlantUnderMaintenance>();
                    var totalInstalledCapacityofPowerPlantData = new List<TotalInstalledCapacityofPowerPlant>();
                    var utilitywiseTotalInstalledCapacityofPowerPlantData = new List<UtilitywiseTotalInstalledCapacityofPowerPlant>();
                    var utilitywiseTotalInstalledCapacityofPowerPlantinOperationData = new List<UtilitywiseTotalInstalledCapacityofPowerPlantinOperation>();
                    var utilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenanceData = new List<UtilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenance>();
                    var fuelWisePowerPlantData = new List<FuelWisePowerPlant>();
                    var pPTypeWisePowerPlantData = new List<PPTypeWisePowerPlant>();
                    var totalDistributionSubStationsData = new List<TotalDistributionSubStations>();

                    await sql.OpenAsync();

                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                insuredNonInsuredAssetData.Add(InsuredNonInsuredAssetMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                serviceLifeAnalysisData.Add(ServiceLifeAnalysisMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                operationalNonOperationalTransformerData.Add(OperationalNonOperationalTransformerMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                landUsagesbyOfficeData.Add(LandUsagesbyOfficeMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                transformerOperationalAnalysisbyOfficeData.Add(TransformerOperationalAnalysisbyOfficeMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                transformerOperationalAnalysisbyMonthData.Add(TransformerOperationalAnalysisbyMonthMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                landAreabyOfficeData.Add(LandAreabyOfficeMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                landEncroachmentRatioData.Add(LandEncroachmentRatioMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                subStationsbyOfficeData.Add(SubStationsbyOfficeMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                totalLandAreaData.Add(TotalLandAreaMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                utilitywiseTotalLandData.Add(UtilitywiseTotalLandMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                totalLandbyUsagesData.Add(TotalLandbyUsagesMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                utilitywiseTotalBuildingData.Add(UtilitywiseTotalBuildingMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                totalNumberofPowerPlantData.Add(TotalNumberofPowerPlantMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                utilitywiseTotalNumberofPowerPlantData.Add(UtilitywiseTotalNumberofPowerPlantMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                utilitywiseTotalNumberofPowerPlantinOperationData.Add(UtilitywiseTotalNumberofPowerPlantinOperationMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                utilitywiseTotalNumberofPowerPlantUnderMaintenanceData.Add(UtilitywiseTotalNumberofPowerPlantUnderMaintenanceMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                totalInstalledCapacityofPowerPlantData.Add(TotalInstalledCapacityofPowerPlantMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                utilitywiseTotalInstalledCapacityofPowerPlantData.Add(UtilitywiseTotalInstalledCapacityofPowerPlantMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                utilitywiseTotalInstalledCapacityofPowerPlantinOperationData.Add(UtilitywiseTotalInstalledCapacityofPowerPlantinOperationMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                utilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenanceData.Add(UtilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenanceMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                fuelWisePowerPlantData.Add(FuelWisePowerPlantMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                pPTypeWisePowerPlantData.Add(PPTypeWisePowerPlantMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                totalDistributionSubStationsData.Add(TotalDistributionSubStationsMapToValue(reader));
                            }

                            response.InsuredNonInsuredAssetsList = insuredNonInsuredAssetData;
                            response.ServiceLifeAnalysesList = serviceLifeAnalysisData;
                            response.OperationalNonOperationalTransformerList = operationalNonOperationalTransformerData;
                            response.LandUsagesbyOfficeList = landUsagesbyOfficeData;
                            response.TransformerOperationalAnalysisbyOfficeList = transformerOperationalAnalysisbyOfficeData;
                            response.TransformerOperationalAnalysisbyMonthList = transformerOperationalAnalysisbyMonthData;
                            response.LandAreabyOfficeList = landAreabyOfficeData;
                            response.LandEncroachmentRatioList = landEncroachmentRatioData;
                            response.SubStationsbyOfficeList = subStationsbyOfficeData;
                            response.TotalLandAreaList = totalLandAreaData;
                            response.UtilitywiseTotalLandList = utilitywiseTotalLandData;
                            response.TotalLandbyUsagesList = totalLandbyUsagesData;
                            response.UtilitywiseTotalBuildingList = utilitywiseTotalBuildingData;
                            response.TotalNumberofPowerPlantList = totalNumberofPowerPlantData;
                            response.UtilitywiseTotalNumberofPowerPlantList = utilitywiseTotalNumberofPowerPlantData;
                            response.UtilitywiseTotalNumberofPowerPlantinOperationList = utilitywiseTotalNumberofPowerPlantinOperationData;
                            response.UtilitywiseTotalNumberofPowerPlantUnderMaintenanceList = utilitywiseTotalNumberofPowerPlantUnderMaintenanceData;
                            response.TotalInstalledCapacityofPowerPlantList = totalInstalledCapacityofPowerPlantData;
                            response.UtilitywiseTotalInstalledCapacityofPowerPlantList = utilitywiseTotalInstalledCapacityofPowerPlantData;
                            response.UtilitywiseTotalInstalledCapacityofPowerPlantinOperationList = utilitywiseTotalInstalledCapacityofPowerPlantinOperationData;
                            response.UtilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenanceList = utilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenanceData;
                            response.FuelWisePowerPlantList = fuelWisePowerPlantData;
                            response.PPTypeWisePowerPlantList = pPTypeWisePowerPlantData;
                            response.TotalDistributionSubStationsList = totalDistributionSubStationsData;
                        }

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                    return response;
                }
            }
        }

        private InsuredNonInsuredAsset InsuredNonInsuredAssetMapToValue(SqlDataReader reader)
        {
            return new InsuredNonInsuredAsset()
            {
                AssetType = reader["AssetType"].ToString(),
                Insured = Convert.ToInt64(reader["Insured"].ToString()),
                NonInsured = Convert.ToInt64(reader["NonInsured"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private ServiceLifeAnalysis ServiceLifeAnalysisMapToValue(SqlDataReader reader)
        {
            return new ServiceLifeAnalysis()
            {
                OfficeName = reader["OfficeName"].ToString(),
                Transformer = Convert.ToInt64(reader["% Transformer > 5y"].ToString()),
                SubStation = Convert.ToInt64(reader["% Distribution Sub-Station > 10Y"].ToString()),
                PowerTransformer = Convert.ToInt64(reader["Power Transformer"].ToString()),
                CircuitBreaker = Convert.ToInt64(reader["% Circuit Breaker > 5y"].ToString()),
                Machinery = Convert.ToInt64(reader[" % Machinery > 5y"].ToString()),
                Vehicle = Convert.ToInt64(reader["% Vehicle > 5y"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private OperationalNonOperationalTransformer OperationalNonOperationalTransformerMapToValue(SqlDataReader reader)
        {
            return new OperationalNonOperationalTransformer()
            {
                OfficeName = reader["OfficeName"].ToString(),
                Operational = Convert.ToInt64(reader["Operational"].ToString()),
                NonOperational = Convert.ToInt64(reader["Non-Operational"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private LandUsagesbyOffice LandUsagesbyOfficeMapToValue(SqlDataReader reader)
        {
            return new LandUsagesbyOffice()
            {
                OfficeName = reader["OfficeName"].ToString(),
                PowerPlant = Convert.ToDouble(reader["PowerPlant"].ToString()),
                SubStation = Convert.ToDouble(reader["SubStation"].ToString()),
                OfficeBuilding = Convert.ToDouble(reader["OfficeBuilding"].ToString()),
                ResidentialBuilding = Convert.ToDouble(reader["ResidentialBuilding"].ToString()),
                Road = Convert.ToDouble(reader["Road"].ToString()),
                UndevelopedLand = Convert.ToDouble(reader["UndevelopedLand"].ToString()),
                Others = Convert.ToDouble(reader["Others"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private TransformerOperationalAnalysisbyOffice TransformerOperationalAnalysisbyOfficeMapToValue(SqlDataReader reader)
        {
            return new TransformerOperationalAnalysisbyOffice()
            {
                OfficeName = reader["OfficeName"].ToString(),
                Overloaded = Convert.ToInt64(reader["Overloaded"].ToString()),
                Burnt = Convert.ToInt64(reader["Burnt"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private TransformerOperationalAnalysisbyMonth TransformerOperationalAnalysisbyMonthMapToValue(SqlDataReader reader)
        {
            return new TransformerOperationalAnalysisbyMonth()
            {
                Month = reader["Month"].ToString(),
                Overloaded = Convert.ToInt64(reader["Overloaded"].ToString()),
                Burnt = Convert.ToInt64(reader["Burnt"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private LandAreabyOffice LandAreabyOfficeMapToValue(SqlDataReader reader)
        {
            return new LandAreabyOffice()
            {
                OfficeName = reader["OfficeName"].ToString(),
                TotalAreaOfLand = Convert.ToInt64(reader["TotalAreaofLand"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private LandEncroachmentRatio LandEncroachmentRatioMapToValue(SqlDataReader reader)
        {
            return new LandEncroachmentRatio()
            {
                Encroachment = Convert.ToInt64(reader["Encroachment"].ToString()),
                PhysicalPossession = Convert.ToInt64(reader["PhysicalPossession"].ToString())
            };
        }
        private SubStationsbyOffice SubStationsbyOfficeMapToValue(SqlDataReader reader)
        {
            return new SubStationsbyOffice()
            {
                OfficeName = reader["OfficeName"].ToString(),
                TotalSubStation = Convert.ToInt64(reader["TotalSubStation"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private TotalLandArea TotalLandAreaMapToValue(SqlDataReader reader)
        {
            return new TotalLandArea()
            {
                TotalArea = Convert.ToInt64(reader["TotalLandArea"].ToString())
            };
        }
        private UtilitywiseTotalLand UtilitywiseTotalLandMapToValue(SqlDataReader reader)
        {
            return new UtilitywiseTotalLand()
            {
                Organization = reader["Organization"].ToString(),
                TotalArea = Convert.ToInt64(reader["TotalLandArea"].ToString())
            };
        }
        private TotalLandbyUsages TotalLandbyUsagesMapToValue(SqlDataReader reader)
        {
            return new TotalLandbyUsages()
            {
                Usages = reader["Usages"].ToString(),
                TotalArea = Convert.ToInt64(reader["TotalLandArea"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private UtilitywiseTotalBuilding UtilitywiseTotalBuildingMapToValue(SqlDataReader reader)
        {
            return new UtilitywiseTotalBuilding()
            {
                Organization = reader["Organization"].ToString(),
                TotalArea = Convert.ToInt64(reader["TotalArea"].ToString())
            };
        }
        private TotalNumberofPowerPlant TotalNumberofPowerPlantMapToValue(SqlDataReader reader)
        {
            return new TotalNumberofPowerPlant()
            {
                TotalPowerPlant = Convert.ToInt64(reader["TotalPowerPlant"].ToString())
            };
        }
        private UtilitywiseTotalNumberofPowerPlant UtilitywiseTotalNumberofPowerPlantMapToValue(SqlDataReader reader)
        {
            return new UtilitywiseTotalNumberofPowerPlant()
            {
                Organization = reader["Organization"].ToString(),
                TotalPowerPlant = Convert.ToInt64(reader["TotalPowerPlant"].ToString())
            };
        }
        private UtilitywiseTotalNumberofPowerPlantinOperation UtilitywiseTotalNumberofPowerPlantinOperationMapToValue(SqlDataReader reader)
        {
            return new UtilitywiseTotalNumberofPowerPlantinOperation()
            {
                Organization = reader["Organization"].ToString(),
                TotalPowerPlant = Convert.ToInt64(reader["TotalPowerPlant"].ToString())
            };
        }
        private UtilitywiseTotalNumberofPowerPlantUnderMaintenance UtilitywiseTotalNumberofPowerPlantUnderMaintenanceMapToValue(SqlDataReader reader)
        {
            return new UtilitywiseTotalNumberofPowerPlantUnderMaintenance()
            {
                Organization = reader["Organization"].ToString(),
                TotalPowerPlant = Convert.ToInt64(reader["TotalPowerPlant"].ToString())
            };
        }
        private TotalInstalledCapacityofPowerPlant TotalInstalledCapacityofPowerPlantMapToValue(SqlDataReader reader)
        {
            return new TotalInstalledCapacityofPowerPlant()
            {
                TotalCapacity = Convert.ToInt64(reader["TotalCapacity"].ToString())
            };
        }
        private UtilitywiseTotalInstalledCapacityofPowerPlant UtilitywiseTotalInstalledCapacityofPowerPlantMapToValue(SqlDataReader reader)
        {
            return new UtilitywiseTotalInstalledCapacityofPowerPlant()
            {
                Organization = reader["Organization"].ToString(),
                TotalCapacity = Convert.ToInt64(reader["TotalCapacity"].ToString())
            };
        }
        private UtilitywiseTotalInstalledCapacityofPowerPlantinOperation UtilitywiseTotalInstalledCapacityofPowerPlantinOperationMapToValue(SqlDataReader reader)
        {
            return new UtilitywiseTotalInstalledCapacityofPowerPlantinOperation()
            {
                Organization = reader["Organization"].ToString(),
                TotalCapacity = Convert.ToInt64(reader["TotalCapacity"].ToString())
            };
        }
        private UtilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenance UtilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenanceMapToValue(SqlDataReader reader)
        {
            return new UtilitywiseTotalInstalledCapacityofPowerPlantUnderMaintenance()
            {
                Organization = reader["Organization"].ToString(),
                TotalCapacity = Convert.ToInt64(reader["TotalCapacity"].ToString())
            };
        }
        private FuelWisePowerPlant FuelWisePowerPlantMapToValue(SqlDataReader reader)
        {
            return new FuelWisePowerPlant()
            {
                FuelType = reader["FuelType"].ToString(),
                TotalPowerPlant = Convert.ToInt64(reader["TotalPowerPlant"].ToString())
            };
        }
        private PPTypeWisePowerPlant PPTypeWisePowerPlantMapToValue(SqlDataReader reader)
        {
            return new PPTypeWisePowerPlant()
            {
                PowerPlantType = reader["PowerPlantType"].ToString(),
                TotalPowerPlant = Convert.ToInt64(reader["TotalPowerPlant"].ToString())
            };
        }
        private TotalDistributionSubStations TotalDistributionSubStationsMapToValue(SqlDataReader reader)
        {
            return new TotalDistributionSubStations()
            {
                TotalDistributionSS = Convert.ToInt64(reader["TotalDistributionSS"].ToString())
            };
        }


        //SP-2 for Usages Wise Land By Org
        public async Task<List<UsagesWiseLandByOrg>> GetUsagesWiseLandByOrg(string org)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetUsagesWiseLandByOrg", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@org", org));

                    var usagesWiseLandByOrgData = new List<UsagesWiseLandByOrg>();

                    await sql.OpenAsync();

                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                usagesWiseLandByOrgData.Add(UsagesWiseLandByOrgMapToValue(reader));
                            }

                        }

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                    return usagesWiseLandByOrgData;
                }
            }
        }

        private UsagesWiseLandByOrg UsagesWiseLandByOrgMapToValue(SqlDataReader reader)
        {
            return new UsagesWiseLandByOrg()
            {
                Usages = reader["Usages"].ToString(),
                TotalArea = Convert.ToInt64(reader["TotalArea"].ToString())

            };
        }

        //SP-3 for Org Wise Land By Usages
        public async Task<List<OrgWiseLandByUsages>> GetOrgWiseLandByUsages(string usages)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetOrgWiseLandByUsages", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@usages", usages));

                    var orgWiseLandByUsagesData = new List<OrgWiseLandByUsages>();

                    await sql.OpenAsync();

                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                orgWiseLandByUsagesData.Add(OrgWiseLandByUsagesMapToValue(reader));
                            }

                        }

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                    return orgWiseLandByUsagesData;
                }
            }
        }

        private OrgWiseLandByUsages OrgWiseLandByUsagesMapToValue(SqlDataReader reader)
        {
            return new OrgWiseLandByUsages()
            {
                Organization = reader["Organization"].ToString(),
                TotalArea = Convert.ToInt64(reader["TotalArea"].ToString())

            };
        }

        //SP-4 for Fule Wisw PP By Org
        public async Task<List<FuleWiswPPByOrg>> GetFuleWiswPPByOrg(string org)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetOFuleWiswPPByOrg", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@org", org));

                    var fuleWiswPPByOrgData = new List<FuleWiswPPByOrg>();

                    await sql.OpenAsync();

                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                fuleWiswPPByOrgData.Add(FuleWiswPPByOrgMapToValue(reader));
                            }

                        }

                    }
                    catch (Exception ex)
                    {

                        throw;
                    }

                    return fuleWiswPPByOrgData;
                }
            }
        }

        private FuleWiswPPByOrg FuleWiswPPByOrgMapToValue(SqlDataReader reader)
        {
            return new FuleWiswPPByOrg()
            {
                FuelType = reader["FuelType"].ToString(),
                TotalPowerPlant = Convert.ToInt64(reader["TotalPowerPlant"].ToString())

            };
        }
    }
}
