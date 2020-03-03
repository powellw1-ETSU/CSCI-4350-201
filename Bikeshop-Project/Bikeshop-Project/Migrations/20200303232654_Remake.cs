using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bikeshop_Project.Migrations
{
    public partial class Remake : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bicycle",
                columns: table => new
                {
                    SERIALNUMBER = table.Column<decimal>(nullable: false),
                    CUSTOMERID = table.Column<decimal>(nullable: false),
                    MODELTYPE = table.Column<string>(nullable: true),
                    PAINTID = table.Column<decimal>(nullable: false),
                    FRAMESIZE = table.Column<double>(nullable: false),
                    ORDERDATE = table.Column<DateTime>(nullable: false),
                    STARTDATE = table.Column<DateTime>(nullable: false),
                    SHIPDATE = table.Column<DateTime>(nullable: false),
                    SHIPEMPLOYEE = table.Column<decimal>(nullable: false),
                    FRAMEASSEMBLER = table.Column<decimal>(nullable: false),
                    PAINTER = table.Column<decimal>(nullable: false),
                    CONSTRUCTION = table.Column<string>(nullable: true),
                    WATERBOTTLEBRAZEONS = table.Column<decimal>(nullable: false),
                    CUSTOMNAME = table.Column<string>(nullable: true),
                    LETTERSTYLEID = table.Column<string>(nullable: true),
                    STOREID = table.Column<decimal>(nullable: false),
                    EMPLOYEEID = table.Column<decimal>(nullable: false),
                    TOPTUBE = table.Column<double>(nullable: false),
                    CHAINSTAY = table.Column<double>(nullable: false),
                    HEADTUBEANGLE = table.Column<double>(nullable: false),
                    SEATTUBEANGLE = table.Column<double>(nullable: false),
                    LISTPRICE = table.Column<decimal>(nullable: false),
                    SALEPRICE = table.Column<decimal>(nullable: false),
                    SALESTAX = table.Column<decimal>(nullable: false),
                    SALESTATE = table.Column<string>(nullable: true),
                    SHIPPRICE = table.Column<decimal>(nullable: false),
                    FRAMEPRICE = table.Column<decimal>(nullable: false),
                    COMPONENTLIST = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bicycle", x => x.SERIALNUMBER);
                });

            migrationBuilder.CreateTable(
                name: "BicycleTubeUsage",
                columns: table => new
                {
                    id = table.Column<decimal>(nullable: false),
                    SERIALNUMBER = table.Column<decimal>(nullable: false),
                    TUBEID = table.Column<decimal>(nullable: false),
                    QUANTITY = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BicycleTubeUsage", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BikeParts",
                columns: table => new
                {
                    id = table.Column<decimal>(nullable: false),
                    SERIALNUMBER = table.Column<decimal>(nullable: false),
                    COMPONENTID = table.Column<decimal>(nullable: false),
                    SUBSTITUTEID = table.Column<decimal>(nullable: false),
                    LOCATION = table.Column<string>(nullable: true),
                    QUANTITY = table.Column<decimal>(nullable: false),
                    DATEINSTALLED = table.Column<DateTime>(nullable: false),
                    EMPLOYEEID = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeParts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "BikeTubes",
                columns: table => new
                {
                    ID = table.Column<decimal>(nullable: false),
                    SERIALNUMBER = table.Column<decimal>(nullable: false),
                    TUBENAME = table.Column<string>(nullable: true),
                    TUBEID = table.Column<decimal>(nullable: false),
                    LENGTH = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BikeTubes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityId = table.Column<string>(nullable: false),
                    ZIPCODE = table.Column<string>(nullable: true),
                    CITY = table.Column<string>(nullable: true),
                    STATE = table.Column<string>(nullable: true),
                    AREACODE = table.Column<string>(nullable: true),
                    POPULATION1990 = table.Column<decimal>(nullable: false),
                    POPULATION1980 = table.Column<decimal>(nullable: false),
                    COUNTRY = table.Column<string>(nullable: true),
                    LATITUDE = table.Column<double>(nullable: false),
                    LONGITUDE = table.Column<double>(nullable: false),
                    POPULATIONCDF = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "CommonSizes",
                columns: table => new
                {
                    ID = table.Column<decimal>(nullable: false),
                    MODELTYPE = table.Column<string>(nullable: true),
                    FRAMESIZE = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonSizes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Component",
                columns: table => new
                {
                    COMPONENTID = table.Column<decimal>(nullable: false),
                    MANUFACTURERID = table.Column<decimal>(nullable: false),
                    PRODUCTNUMBER = table.Column<string>(nullable: true),
                    ROAD = table.Column<string>(nullable: true),
                    CATEGORY = table.Column<string>(nullable: true),
                    LENGTH = table.Column<double>(nullable: false),
                    HEIGHT = table.Column<double>(nullable: false),
                    WIDTH = table.Column<double>(nullable: false),
                    WEIGHT = table.Column<double>(nullable: false),
                    YEAR = table.Column<decimal>(nullable: false),
                    ENDYEAR = table.Column<decimal>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    LISTPRICE = table.Column<decimal>(nullable: false),
                    ESTIMATEDCOST = table.Column<decimal>(nullable: false),
                    QUANTITYONHAND = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Component", x => x.COMPONENTID);
                });

            migrationBuilder.CreateTable(
                name: "ComponentName",
                columns: table => new
                {
                    COMPONENTNAME = table.Column<string>(nullable: false),
                    ASSEMBLYORDER = table.Column<decimal>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentName", x => x.COMPONENTNAME);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CUSTOMERID = table.Column<decimal>(nullable: false),
                    PHONE = table.Column<string>(nullable: true),
                    FIRSTNAME = table.Column<string>(nullable: true),
                    LASTNAME = table.Column<string>(nullable: true),
                    ADDRESS = table.Column<string>(nullable: true),
                    ZIPCODE = table.Column<string>(nullable: true),
                    CITYID = table.Column<decimal>(nullable: false),
                    BALANCEDUE = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CUSTOMERID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTransaction",
                columns: table => new
                {
                    id = table.Column<decimal>(nullable: false),
                    CUSTOMERID = table.Column<decimal>(nullable: false),
                    TRANSACTIONDATE = table.Column<DateTime>(nullable: false),
                    EMPLOYEEID = table.Column<decimal>(nullable: false),
                    AMOUNT = table.Column<decimal>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    REFERENCE = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTransaction", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EMPLOYEEID = table.Column<decimal>(nullable: false),
                    TAXPAYERID = table.Column<string>(nullable: true),
                    LASTNAME = table.Column<string>(nullable: true),
                    FIRSTNAME = table.Column<string>(nullable: true),
                    HOMEPHONE = table.Column<string>(nullable: true),
                    ADDRESS = table.Column<string>(nullable: true),
                    ZIPCODE = table.Column<string>(nullable: true),
                    CITYID = table.Column<decimal>(nullable: false),
                    DATEHIRED = table.Column<DateTime>(nullable: false),
                    DATERELEASED = table.Column<DateTime>(nullable: false),
                    CURRENTMANAGER = table.Column<decimal>(nullable: false),
                    SALARYGRADE = table.Column<decimal>(nullable: false),
                    SALARY = table.Column<decimal>(nullable: false),
                    TITLE = table.Column<string>(nullable: true),
                    WORKAREA = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EMPLOYEEID);
                });

            migrationBuilder.CreateTable(
                name: "GroupComponents",
                columns: table => new
                {
                    id = table.Column<decimal>(nullable: false),
                    GROUPID = table.Column<decimal>(nullable: false),
                    COMPONENTID = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupComponents", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "GroupO",
                columns: table => new
                {
                    COMPONENTGROUPID = table.Column<decimal>(nullable: false),
                    GROUPNAME = table.Column<string>(nullable: true),
                    BIKETYPE = table.Column<string>(nullable: true),
                    YEAR = table.Column<decimal>(nullable: false),
                    ENDYEAR = table.Column<decimal>(nullable: false),
                    WEIGHT = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupO", x => x.COMPONENTGROUPID);
                });

            migrationBuilder.CreateTable(
                name: "LetterStyle",
                columns: table => new
                {
                    LETTERSTYLE = table.Column<string>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LetterStyle", x => x.LETTERSTYLE);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    MANUFACTURERID = table.Column<decimal>(nullable: false),
                    MANUFACTURERNAME = table.Column<string>(nullable: true),
                    CONTACTNAME = table.Column<string>(nullable: true),
                    PHONE = table.Column<string>(nullable: true),
                    ADDRESS = table.Column<string>(nullable: true),
                    ZIPCODE = table.Column<string>(nullable: true),
                    CITYID = table.Column<decimal>(nullable: false),
                    BALANCEDUE = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.MANUFACTURERID);
                });

            migrationBuilder.CreateTable(
                name: "ManufacturerTransaction",
                columns: table => new
                {
                    id = table.Column<decimal>(nullable: false),
                    MANUFACTURERID = table.Column<decimal>(nullable: false),
                    TRANSACTIONDATE = table.Column<DateTime>(nullable: false),
                    EMPLOYEEID = table.Column<decimal>(nullable: false),
                    AMOUNT = table.Column<decimal>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    REFERENCE = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufacturerTransaction", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ModelSize",
                columns: table => new
                {
                    id = table.Column<decimal>(nullable: false),
                    MODELTYPE = table.Column<string>(nullable: true),
                    MSIZE = table.Column<double>(nullable: false),
                    TOPTUBE = table.Column<double>(nullable: false),
                    CHAINSTAY = table.Column<double>(nullable: false),
                    TOTALLENGTH = table.Column<double>(nullable: false),
                    GROUNDCLEARANCE = table.Column<double>(nullable: false),
                    HEADTUBEANGLE = table.Column<double>(nullable: false),
                    SEATTUBEANGEL = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelSize", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ModelType",
                columns: table => new
                {
                    MODELTYPE = table.Column<string>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    COMPONENTID = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelType", x => x.MODELTYPE);
                });

            migrationBuilder.CreateTable(
                name: "Paint",
                columns: table => new
                {
                    PAINTID = table.Column<decimal>(nullable: false),
                    COLORNAME = table.Column<string>(nullable: true),
                    COLORSTYLE = table.Column<string>(nullable: true),
                    COLORLIST = table.Column<string>(nullable: true),
                    DATEINTRODUCED = table.Column<DateTime>(nullable: false),
                    DATEDISCONTINUED = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paint", x => x.PAINTID);
                });

            migrationBuilder.CreateTable(
                name: "Preference",
                columns: table => new
                {
                    ITEMNAME = table.Column<string>(nullable: false),
                    VALUE = table.Column<double>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    DATECHANGED = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preference", x => x.ITEMNAME);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseItem",
                columns: table => new
                {
                    id = table.Column<decimal>(nullable: false),
                    PURCHASEID = table.Column<decimal>(nullable: false),
                    COMPONENTID = table.Column<decimal>(nullable: false),
                    PRICEPAID = table.Column<decimal>(nullable: false),
                    QUANTITY = table.Column<decimal>(nullable: false),
                    QUANTITYRECEIVED = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseItem", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrder",
                columns: table => new
                {
                    PURCHASEID = table.Column<decimal>(nullable: false),
                    EMPLOYEEID = table.Column<decimal>(nullable: false),
                    MANUFACTURERID = table.Column<decimal>(nullable: false),
                    TOTALLIST = table.Column<decimal>(nullable: false),
                    SHIPPINGCOST = table.Column<decimal>(nullable: false),
                    DISCOUNT = table.Column<decimal>(nullable: false),
                    ORDERDATE = table.Column<DateTime>(nullable: false),
                    RECEIVEDATE = table.Column<DateTime>(nullable: false),
                    AMOUNTDUE = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrder", x => x.PURCHASEID);
                });

            migrationBuilder.CreateTable(
                name: "RetailStore",
                columns: table => new
                {
                    STOREID = table.Column<decimal>(nullable: false),
                    STORENAME = table.Column<string>(nullable: true),
                    PHONE = table.Column<string>(nullable: true),
                    CONTACTFIRSTNAME = table.Column<string>(nullable: true),
                    CONTACTLASTNAME = table.Column<string>(nullable: true),
                    ADDRESS = table.Column<string>(nullable: true),
                    ZIPCODE = table.Column<string>(nullable: true),
                    CITYID = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetailStore", x => x.STOREID);
                });

            migrationBuilder.CreateTable(
                name: "RevisionHistory",
                columns: table => new
                {
                    ID = table.Column<decimal>(nullable: false),
                    VERSION = table.Column<string>(nullable: true),
                    CHANGEDATE = table.Column<DateTime>(nullable: false),
                    NAME = table.Column<string>(nullable: true),
                    REVISIONCOMMENTS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RevisionHistory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SampleName",
                columns: table => new
                {
                    ID = table.Column<decimal>(nullable: false),
                    LASTNAME = table.Column<string>(nullable: true),
                    FIRSTNAME = table.Column<string>(nullable: true),
                    GENDER = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleName", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SampleStreet",
                columns: table => new
                {
                    ID = table.Column<decimal>(nullable: false),
                    BASEADDRESS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SampleStreet", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StateTaxRate",
                columns: table => new
                {
                    STATE = table.Column<string>(nullable: false),
                    TAXRATE = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateTaxRate", x => x.STATE);
                });

            migrationBuilder.CreateTable(
                name: "TempDateMade",
                columns: table => new
                {
                    DATEVALUE = table.Column<DateTime>(nullable: false),
                    MADECOUNT = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TempDateMade", x => x.DATEVALUE);
                });

            migrationBuilder.CreateTable(
                name: "TubeMaterial",
                columns: table => new
                {
                    TUBEID = table.Column<decimal>(nullable: false),
                    MATERIAL = table.Column<string>(nullable: true),
                    DESCRIPTION = table.Column<string>(nullable: true),
                    DIAMETER = table.Column<double>(nullable: false),
                    THICKNESS = table.Column<double>(nullable: false),
                    ROUNDNESS = table.Column<string>(nullable: true),
                    WEIGHT = table.Column<double>(nullable: false),
                    STIFFNESS = table.Column<double>(nullable: false),
                    LISTPRICE = table.Column<double>(nullable: false),
                    CONSTRUCTION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TubeMaterial", x => x.TUBEID);
                });

            migrationBuilder.CreateTable(
                name: "WorkArea",
                columns: table => new
                {
                    WORKAREAID = table.Column<string>(nullable: false),
                    DESCRIPTION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkArea", x => x.WORKAREAID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bicycle");

            migrationBuilder.DropTable(
                name: "BicycleTubeUsage");

            migrationBuilder.DropTable(
                name: "BikeParts");

            migrationBuilder.DropTable(
                name: "BikeTubes");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "CommonSizes");

            migrationBuilder.DropTable(
                name: "Component");

            migrationBuilder.DropTable(
                name: "ComponentName");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "CustomerTransaction");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "GroupComponents");

            migrationBuilder.DropTable(
                name: "GroupO");

            migrationBuilder.DropTable(
                name: "LetterStyle");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropTable(
                name: "ManufacturerTransaction");

            migrationBuilder.DropTable(
                name: "ModelSize");

            migrationBuilder.DropTable(
                name: "ModelType");

            migrationBuilder.DropTable(
                name: "Paint");

            migrationBuilder.DropTable(
                name: "Preference");

            migrationBuilder.DropTable(
                name: "PurchaseItem");

            migrationBuilder.DropTable(
                name: "PurchaseOrder");

            migrationBuilder.DropTable(
                name: "RetailStore");

            migrationBuilder.DropTable(
                name: "RevisionHistory");

            migrationBuilder.DropTable(
                name: "SampleName");

            migrationBuilder.DropTable(
                name: "SampleStreet");

            migrationBuilder.DropTable(
                name: "StateTaxRate");

            migrationBuilder.DropTable(
                name: "TempDateMade");

            migrationBuilder.DropTable(
                name: "TubeMaterial");

            migrationBuilder.DropTable(
                name: "WorkArea");
        }
    }
}
