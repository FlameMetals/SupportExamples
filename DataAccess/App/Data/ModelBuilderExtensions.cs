using Microsoft.EntityFrameworkCore;
using System;


namespace FFM.DataAccess.App
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {



            // ---- This First Section Seeds the database with Container Storage Locations:
            // All Container Storage locations are seed with unique guid, and a name
            // see G:/Tracking/Racking-Layout-BarCodes.xlsx  for the excel spreadsheet where this was created!!
            // The First Item will be well-spaced to show data structure
            // The following objects will all be contained in one line.
            modelBuilder.Entity<DataAccessModels.App.customerPartsHeader>().HasData(
                new DataAccessModels.App.customerPartsHeader
                {
                    id = Guid.Parse("596EFBFF-8C30-4B75-BFDB-EF7E05B5F96D"),
                    isActive = true,
                    isDeleted = false,
                    lastModifiedOnDate = null,
                    lastModifiedByUserId = null,
                    lastModifiedByIp = null,
                    deletedOnDate = null,
                    deletedByUserId = null,
                    approvedRejectedByUserId = null,
                    approvedRejectedOnDate = null,
                    approvedRejectedByIp = ""
                });


            modelBuilder.Entity<DataAccessModels.App.customerParts>().HasData(
                new DataAccessModels.App.customerParts
                {
                    id = Guid.Parse("BF4349A0-2CBA-4646-BAA7-0BAFEEBA9F8C"),
                    createdOnDate = new DateTime(2018, 12, 17, 9, 32, 20, 426, DateTimeKind.Unspecified),
                    createdByUserId = Guid.Parse("31A1793A-9453-48CD-9909-7C157DAE6A8A"),
                    createdByIp = "",
                    customerPartsHeaderId = Guid.Parse("596EFBFF-8C30-4B75-BFDB-EF7E05B5F96D"),
                    userfriendlyName = "OLD CUSTOMER PART",
                    name = "name 1",
                    description = "desc 1"
                },
                new DataAccessModels.App.customerParts
                {
                    id = Guid.Parse("D13195C6-2D9E-46B0-B633-AA9E074EA15F"),
                    createdOnDate = new DateTime(2019, 6, 17, 9, 32, 20, 426, DateTimeKind.Unspecified),
                    createdByUserId = Guid.Parse("31A1793A-9453-48CD-9909-7C157DAE6A8A"),
                    createdByIp = "",
                    customerPartsHeaderId = Guid.Parse("596EFBFF-8C30-4B75-BFDB-EF7E05B5F96D"),
                    userfriendlyName = "NEW CUSTOMER PART",
                    name = "Name Changed",
                    description = "New Description"
                }

                );




            modelBuilder.Entity<DataAccessModels.App.orderPartsHeader>().HasData(
                new DataAccessModels.App.orderPartsHeader
                {
                    id = Guid.Parse("5AB4CB69-7982-44FA-97CD-03E1D386E5E6"),
                    isActive = true,
                    isDeleted = false,
                    lastModifiedOnDate = null,
                    lastModifiedByUserId = null,
                    lastModifiedByIp = null,
                    deletedOnDate = null,
                    deletedByUserId = null,
                    approvedRejectedByUserId = null,
                    approvedRejectedOnDate = null,
                    approvedRejectedByIp = "",
                    lineNumber = 1
                });


            modelBuilder.Entity<DataAccessModels.App.orderParts>().HasData(
                new DataAccessModels.App.orderParts
                {
                    id = Guid.Parse("579F9060-4B69-4AC6-B1D1-D7988F3F5D26"),
                    createdOnDate = new DateTime(2018, 12, 17, 9, 32, 20, 426, DateTimeKind.Unspecified),
                    createdByUserId = Guid.Parse("31A1793A-9453-48CD-9909-7C157DAE6A8A"),
                    createdByIp = "",
                    orderPartsHeaderId = Guid.Parse("5AB4CB69-7982-44FA-97CD-03E1D386E5E6"),
                    userfriendlyName = "Order Part 1",
                    orderQty = 100,
                    orderWt = (decimal?)2.3,
                    customerPartsId = Guid.Parse("BF4349A0-2CBA-4646-BAA7-0BAFEEBA9F8C")
                }

                );
















        }
    }

}