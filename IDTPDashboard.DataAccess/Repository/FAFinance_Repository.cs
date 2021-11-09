using IDTPDashboard.DataAccess.Interface;
using IDTPDashboard.DomainModel.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace IDTPDashboard.DataAccess.Repository
{
    public class FAFinance_Repository : IFAFinance_Repository
    {
        private readonly string _connectionString;
        public FAFinance_Repository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AzureDbConnection");
        }
        public async Task<FAFinance_Entity> GetAllReports(string Organization)
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("FAF_Dashboard", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@Organization", Organization));

                    var response = new FAFinance_Entity();
                    var MaintenanceCostbyOfficeData = new List<MaintenanceCostbyOffice>();
                    var AssetAcquisitionOfficeWiseData = new List<AssetAcquisitionOfficeWise>();
                    var LandValuebyOfficeData = new List<LandValuebyOffice>();
                    var BookValuevsAccumulatedPriceData = new List<BookValuevsAccumulatedPrice>();
                    var AssetDisposedAssetWiseData = new List<AssetDisposedAssetWise>();
                    var AssetDisposedOfficeWiseData = new List<AssetDisposedOfficeWise>();
                    var AssetAcquisitionAssetWiseData = new List<AssetAcquisitionAssetWise>();
                    var MaintenanceCostbyMonthData = new List<MaintenanceCostbyMonth>();
                    var BookValuebyAssetTypeData = new List<BookValuebyAssetType>();
                    var AcquisitionVsBookValueData = new List<AcquisitionVsBookValue>();


                    await sql.OpenAsync();

                    try
                    {
                        using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                MaintenanceCostbyOfficeData.Add(MaintenanceCostbyOfficeMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                AssetAcquisitionOfficeWiseData.Add(AssetAcquisitionOfficeWiseMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                LandValuebyOfficeData.Add(LandValuebyOfficeMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                BookValuevsAccumulatedPriceData.Add(BookValuevsAccumulatedPriceMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                AssetDisposedAssetWiseData.Add(AssetDisposedAssetWiseMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                AssetDisposedOfficeWiseData.Add(AssetDisposedOfficeWiseMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                AssetAcquisitionAssetWiseData.Add(AssetAcquisitionAssetWiseMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                MaintenanceCostbyMonthData.Add(MaintenanceCostbyMonthMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                BookValuebyAssetTypeData.Add(BookValuebyAssetTypeMapToValue(reader));
                            }
                            await reader.NextResultAsync();
                            while (await reader.ReadAsync())
                            {
                                AcquisitionVsBookValueData.Add(AcquisitionVsBookValueMapToValue(reader));
                            }

                            response.MaintenanceCostbyOfficeList = MaintenanceCostbyOfficeData;
                            response.AssetAcquisitionOfficeWiseList = AssetAcquisitionOfficeWiseData;
                            response.LandValuebyOfficeList = LandValuebyOfficeData;
                            response.BookValuevsAccumulatedPriceList = BookValuevsAccumulatedPriceData;
                            response.AssetDisposedAssetWiseList = AssetDisposedAssetWiseData;
                            response.AssetDisposedOfficeWiseList = AssetDisposedOfficeWiseData;
                            response.AssetAcquisitionAssetWiseList = AssetAcquisitionAssetWiseData;
                            response.MaintenanceCostbyMonthList = MaintenanceCostbyMonthData;
                            response.BookValuebyAssetTypeList = BookValuebyAssetTypeData;
                            response.AcquisitionVsBookValueList = AcquisitionVsBookValueData;
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
        private MaintenanceCostbyOffice MaintenanceCostbyOfficeMapToValue(SqlDataReader reader)
        {
            return new MaintenanceCostbyOffice()
            {
                OfficeName = reader["OfficeName"].ToString(),
                Transformer = Convert.ToInt64(reader["Transormer"].ToString()),
                Vehicle = Convert.ToInt64(reader["Vehicle"].ToString()),
                OfficeEuqipment = Convert.ToInt64(reader["OfficeEuqipment"].ToString()),
                Building = Convert.ToInt64(reader["Building"].ToString()),
                CivilWorks = Convert.ToInt64(reader["CivilWorks"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private AssetAcquisitionOfficeWise AssetAcquisitionOfficeWiseMapToValue(SqlDataReader reader)
        {
            return new AssetAcquisitionOfficeWise()
            {
                OfficeName = reader["OfficeName"].ToString(),
                AcquisitionAmount = Convert.ToInt64(reader["AcquisitionAmount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private LandValuebyOffice LandValuebyOfficeMapToValue(SqlDataReader reader)
        {
            return new LandValuebyOffice()
            {
                OfficeName = reader["OfficeName"].ToString(),
                LandValue = Convert.ToInt64(reader["LandValue"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private BookValuevsAccumulatedPrice BookValuevsAccumulatedPriceMapToValue(SqlDataReader reader)
        {
            return new BookValuevsAccumulatedPrice()
            {
                AssetSubType = reader["AssetSubType"].ToString(),
                BookValue = Convert.ToDouble(reader["BookValue"].ToString()),
                AccumulatedDepreciation = Convert.ToDouble(reader["AccumulatedDepreciation"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private AssetDisposedAssetWise AssetDisposedAssetWiseMapToValue(SqlDataReader reader)
        {
            return new AssetDisposedAssetWise()
            {
                AssetType = reader["AssetType"].ToString(),
                SoldAmount = Convert.ToInt64(reader["SoldAmount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private AssetDisposedOfficeWise AssetDisposedOfficeWiseMapToValue(SqlDataReader reader)
        {
            return new AssetDisposedOfficeWise()
            {
                OfficeName = reader["OfficeName"].ToString(),
                SoldAmount = Convert.ToInt64(reader["SoldAmount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private AssetAcquisitionAssetWise AssetAcquisitionAssetWiseMapToValue(SqlDataReader reader)
        {
            return new AssetAcquisitionAssetWise()
            {
                AssetType = reader["AssetType"].ToString(),
                AcquisitionAmount = Convert.ToInt64(reader["AcquisitionAmount"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private MaintenanceCostbyMonth MaintenanceCostbyMonthMapToValue(SqlDataReader reader)
        {
            return new MaintenanceCostbyMonth()
            {
                Month = reader["Month"].ToString(),
                MaintenanceCost = Convert.ToInt64(reader["MaintenanceCost"].ToString()),
                SequenceNo = Convert.ToInt32(reader["SequenceNo"].ToString())
            };
        }
        private BookValuebyAssetType BookValuebyAssetTypeMapToValue(SqlDataReader reader)
        {
            return new BookValuebyAssetType()
            {
                AssetType = reader["AssetType"].ToString(),
                BookValue = Convert.ToDouble(reader["BookValue"].ToString())
            };
        }
        private AcquisitionVsBookValue AcquisitionVsBookValueMapToValue(SqlDataReader reader)
        {
            return new AcquisitionVsBookValue()
            {
                AssetType = reader["AssetType"].ToString(),
                BookValue = Convert.ToDouble(reader["BookValue"].ToString()),
                Acquisition = Convert.ToDouble(reader["Acquisition"].ToString()),
                Organization = reader["Organization"].ToString()
            };
        }
    }
}
