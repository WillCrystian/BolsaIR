using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BolsaIR.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brokers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Cnpj = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Website = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    ImporterName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brokers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    TradingName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Cnpj = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Sector = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Segment = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Website = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BrokerageNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BrokerId = table.Column<Guid>(type: "TEXT", nullable: false),
                    NoteNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TradeDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Imported = table.Column<bool>(type: "INTEGER", nullable: false),
                    ImportedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Observation = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    TotalValue = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    NetValue = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    SettlementDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LiquidValue = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    BrokerageFee = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    ExchangeFee = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    RegistrationFee = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    SettlementFee = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    Emoluments = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    OtherFees = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    Irrf = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrokerageNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BrokerageNotes_Brokers_BrokerId",
                        column: x => x.BrokerId,
                        principalTable: "Brokers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Ticker = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    TradingName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    CompanyName = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Cnpj = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Isin = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    AssetType = table.Column<int>(type: "INTEGER", nullable: false),
                    Sector = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Segment = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CompanyId = table.Column<Guid>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assets_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CorporateActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AssetId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    ApprovedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EffectiveDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Factor = table.Column<decimal>(type: "TEXT", precision: 18, scale: 8, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    ExternalId = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorporateActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CorporateActions_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dividends",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AssetId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    ExDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ValuePerShare = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ExternalId = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dividends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dividends_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    BrokerageNoteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AssetId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OperationType = table.Column<int>(type: "INTEGER", nullable: false),
                    TradeType = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    SettlementDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    BrokerageFee = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    ExchangeFee = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    RegistrationFee = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    SettlementFee = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    Emoluments = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    OtherFees = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    Irrf = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    Observation = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    ExternalId = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Processed = table.Column<bool>(type: "INTEGER", nullable: false),
                    ProcessedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Operations_BrokerageNotes_BrokerageNoteId",
                        column: x => x.BrokerageNoteId,
                        principalTable: "BrokerageNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AssetId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<decimal>(type: "TEXT", precision: 18, scale: 8, nullable: false),
                    AveragePrice = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    TotalCost = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    LastMovementDate = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Positions_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Quotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AssetId = table.Column<Guid>(type: "TEXT", nullable: false),
                    TradingDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Open = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    High = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    Low = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    Close = table.Column<decimal>(type: "TEXT", precision: 18, scale: 6, nullable: false),
                    Volume = table.Column<long>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Quotes_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assets_CompanyId",
                table: "Assets",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Assets_Ticker",
                table: "Assets",
                column: "Ticker",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BrokerageNotes_BrokerId_NoteNumber",
                table: "BrokerageNotes",
                columns: new[] { "BrokerId", "NoteNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brokers_Name",
                table: "Brokers",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_Cnpj",
                table: "Companies",
                column: "Cnpj",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CorporateActions_AssetId_ApprovedDate_Type",
                table: "CorporateActions",
                columns: new[] { "AssetId", "ApprovedDate", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Dividends_AssetId_ExDate_Type",
                table: "Dividends",
                columns: new[] { "AssetId", "ExDate", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_Date",
                table: "Holidays",
                column: "Date",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Operations_AssetId_SettlementDate",
                table: "Operations",
                columns: new[] { "AssetId", "SettlementDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_BrokerageNoteId",
                table: "Operations",
                column: "BrokerageNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_ExternalId",
                table: "Operations",
                column: "ExternalId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_Processed_SettlementDate",
                table: "Operations",
                columns: new[] { "Processed", "SettlementDate" });

            migrationBuilder.CreateIndex(
                name: "IX_Positions_AssetId",
                table: "Positions",
                column: "AssetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Quotes_AssetId_TradingDate",
                table: "Quotes",
                columns: new[] { "AssetId", "TradingDate" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CorporateActions");

            migrationBuilder.DropTable(
                name: "Dividends");

            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Quotes");

            migrationBuilder.DropTable(
                name: "BrokerageNotes");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Brokers");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
