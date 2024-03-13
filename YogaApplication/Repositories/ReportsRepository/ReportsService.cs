using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaApplication.Model;

namespace YogaApplication.Repositories.ReportsRepository
{
    /// <summary>
    /// Service class for managing reports data, extending the <see cref="DatabaseInit"/> class.
    /// </summary>
    internal class ReportsService : DatabaseInit
    {
        /// <summary>
        /// Saves a report data asynchronously.
        /// </summary>
        /// <param name="reportData">The report data to save.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SaveReportDataAsync(ReportData reportData)
        {
            await Init();
            if (reportData.Id == 0)
            {
                // Insert the report data into the database
                Database.Insert(reportData);
                // Commit changes to the database
                Database.Commit();
            }
            else
            {
                // Update the existing report data in the database
                Database.Update(reportData);
                // Commit changes to the database
                Database.Commit();
            }
        }

        /// <summary>
        /// Retrieves all report data from the database asynchronously.
        /// </summary>
        /// <returns>A task representing the asynchronous operation that returns a list of report data.</returns>
        public async Task<List<ReportData>> GetReportData()
        {
            await Init();
            // Retrieve all report data from the database and return them as a list
            return Database.Table<ReportData>().ToList();
        }

        /// <summary>
        /// Finalizer for the <see cref="ReportsService"/> class.
        /// </summary>
        ~ReportsService()
        {
            // Close the database connection when the object is finalized
            Database?.Close();
        }
    }

}
