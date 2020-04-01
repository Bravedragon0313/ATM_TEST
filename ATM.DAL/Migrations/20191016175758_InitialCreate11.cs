using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ATM.DAL.Migrations
{
    public partial class InitialCreate11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Blacklist",
                table: "Blacklist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bills",
                table: "Bill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashOutRefills",
                table: "CashOutRefill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashOutActions",
                table: "CashOutAction");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashInRefills",
                table: "CashInRefill");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CashInActions",
                table: "CashInAction");

            migrationBuilder.RenameTable(
                name: "Blacklist",
                newName: "blacklist");

            migrationBuilder.RenameTable(
                name: "Bill",
                newName: "bills");

            migrationBuilder.RenameTable(
                name: "CashOutRefill",
                newName: "cash_out_refills");

            migrationBuilder.RenameTable(
                name: "CashOutAction",
                newName: "cash_out_actions");

            migrationBuilder.RenameTable(
                name: "CashInRefill",
                newName: "cash_in_refills");

            migrationBuilder.RenameTable(
                name: "CashInAction",
                newName: "cash_in_actions");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "blacklist",
                newName: "address");

            migrationBuilder.RenameColumn(
                name: "CryptoCode",
                table: "blacklist",
                newName: "crypto_code");

            migrationBuilder.RenameColumn(
                name: "CreatedByOperator",
                table: "blacklist",
                newName: "created_by_operator");

            migrationBuilder.RenameColumn(
                name: "Fiat",
                table: "bills",
                newName: "fiat");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "bills",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "bills",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FiatCode",
                table: "bills",
                newName: "fiat_code");

            migrationBuilder.RenameColumn(
                name: "DeviceTime",
                table: "bills",
                newName: "device_time");

            migrationBuilder.RenameColumn(
                name: "CryptoCode",
                table: "bills",
                newName: "crypto_code");

            migrationBuilder.RenameColumn(
                name: "CryptoAtomsAfterFee",
                table: "bills",
                newName: "crypto_atoms_after_fee");

            migrationBuilder.RenameColumn(
                name: "CryptoAtoms",
                table: "bills",
                newName: "crypto_atoms");

            migrationBuilder.RenameColumn(
                name: "CashInTxsId",
                table: "bills",
                newName: "cash_in_txs_id");

            migrationBuilder.RenameColumn(
                name: "CashInFeeCrypto",
                table: "bills",
                newName: "cash_in_fee_crypto");

            migrationBuilder.RenameColumn(
                name: "CashInFee",
                table: "bills",
                newName: "cash_in_fee");

            migrationBuilder.RenameColumn(
                name: "Denomination2",
                table: "cash_out_refills",
                newName: "denomination2");

            migrationBuilder.RenameColumn(
                name: "Denomination1",
                table: "cash_out_refills",
                newName: "denomination1");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "cash_out_refills",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Cassette2",
                table: "cash_out_refills",
                newName: "cassette2");

            migrationBuilder.RenameColumn(
                name: "Cassette1",
                table: "cash_out_refills",
                newName: "cassette1");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cash_out_refills",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "cash_out_refills",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "DeviceId",
                table: "cash_out_refills",
                newName: "device_id");

            migrationBuilder.RenameColumn(
                name: "Redeem",
                table: "cash_out_actions",
                newName: "redeem");

            migrationBuilder.RenameColumn(
                name: "Error",
                table: "cash_out_actions",
                newName: "error");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "cash_out_actions",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Action",
                table: "cash_out_actions",
                newName: "action");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cash_out_actions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TxId",
                table: "cash_out_actions",
                newName: "tx_id");

            migrationBuilder.RenameColumn(
                name: "TxHash",
                table: "cash_out_actions",
                newName: "tx_hash");

            migrationBuilder.RenameColumn(
                name: "ToAddress",
                table: "cash_out_actions",
                newName: "to_address");

            migrationBuilder.RenameColumn(
                name: "Rejected2",
                table: "cash_out_actions",
                newName: "rejected_2");

            migrationBuilder.RenameColumn(
                name: "Rejected1",
                table: "cash_out_actions",
                newName: "rejected_1");

            migrationBuilder.RenameColumn(
                name: "Provisioned2",
                table: "cash_out_actions",
                newName: "provisioned_2");

            migrationBuilder.RenameColumn(
                name: "Provisioned1",
                table: "cash_out_actions",
                newName: "provisioned_1");

            migrationBuilder.RenameColumn(
                name: "Layer2Address",
                table: "cash_out_actions",
                newName: "layer_2_address");

            migrationBuilder.RenameColumn(
                name: "ErrorCode",
                table: "cash_out_actions",
                newName: "error_code");

            migrationBuilder.RenameColumn(
                name: "Dispensed2",
                table: "cash_out_actions",
                newName: "dispensed_2");

            migrationBuilder.RenameColumn(
                name: "Dispensed1",
                table: "cash_out_actions",
                newName: "dispensed_1");

            migrationBuilder.RenameColumn(
                name: "DeviceTime",
                table: "cash_out_actions",
                newName: "device_time");

            migrationBuilder.RenameColumn(
                name: "DeviceId",
                table: "cash_out_actions",
                newName: "device_id");

            migrationBuilder.RenameColumn(
                name: "Denomination2",
                table: "cash_out_actions",
                newName: "denomination_2");

            migrationBuilder.RenameColumn(
                name: "Denomination1",
                table: "cash_out_actions",
                newName: "denomination_1");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "cash_in_refills",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cash_in_refills",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "cash_in_refills",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "DeviceId",
                table: "cash_in_refills",
                newName: "device_id");

            migrationBuilder.RenameColumn(
                name: "CashBoxCount",
                table: "cash_in_refills",
                newName: "cash_box_count");

            migrationBuilder.RenameColumn(
                name: "Error",
                table: "cash_in_actions",
                newName: "error");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "cash_in_actions",
                newName: "created");

            migrationBuilder.RenameColumn(
                name: "Action",
                table: "cash_in_actions",
                newName: "action");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "cash_in_actions",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TxId",
                table: "cash_in_actions",
                newName: "tx_id");

            migrationBuilder.RenameColumn(
                name: "TxHash",
                table: "cash_in_actions",
                newName: "tx_hash");

            migrationBuilder.RenameColumn(
                name: "ErrorCode",
                table: "cash_in_actions",
                newName: "error_code");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:cash_out_action_types", "published,authorized,instant,confirmed,rejected,insufficientFunds,dispenseRequested,dispensed,notified,addedPhone,redeem")
                .Annotation("Npgsql:Enum:compliance_type", "authorized,sms,id_card_data,id_card_photo,sanctions,front_camera,hard_limit")
                .Annotation("Npgsql:Enum:status_stage", "notSeen,published,authorized,instant,confirmed,rejected,insufficientFunds")
                .Annotation("Npgsql:Enum:trade_type", "buy,sell")
                .Annotation("Npgsql:Enum:transaction_authority", "timeout,machine,pending,rejected,published,authorized,confirmed")
                .Annotation("Npgsql:Enum:transaction_stage", "initial_request,partial_request,final_request,partial_send,deposit,dispense_request,dispense")
                .Annotation("Npgsql:Enum:verification_type", "verified,blocked,automatic");

            migrationBuilder.AlterColumn<string>(
                name: "address",
                table: "blacklist",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "blacklist",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "crypto_code",
                table: "blacklist",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "created_by_operator",
                table: "blacklist",
                nullable: false,
                defaultValueSql: "true",
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "bills",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "fiat_code",
                table: "bills",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "crypto_code",
                table: "bills",
                nullable: true,
                defaultValueSql: "'BTC'::text",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "crypto_atoms_after_fee",
                table: "bills",
                type: "numeric(30,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "crypto_atoms",
                table: "bills",
                type: "numeric(30,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "cash_in_fee_crypto",
                table: "bills",
                type: "numeric(30,0)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "cash_in_fee",
                table: "bills",
                type: "numeric(14,5)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "cash_out_refills",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "device_id",
                table: "cash_out_refills",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "cash_out_actions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "action",
                table: "cash_out_actions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "device_id",
                table: "cash_out_actions",
                nullable: false,
                defaultValueSql: "''::text",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "cash_in_refills",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "device_id",
                table: "cash_in_refills",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created",
                table: "cash_in_actions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "action",
                table: "cash_in_actions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_bills",
                table: "bills",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cash_out_refills",
                table: "cash_out_refills",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cash_out_actions",
                table: "cash_out_actions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cash_in_refills",
                table: "cash_in_refills",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cash_in_actions",
                table: "cash_in_actions",
                column: "id");

            migrationBuilder.CreateTable(
                name: "aggregated_machine_pings",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    device_id = table.Column<string>(nullable: false),
                    dropped_pings = table.Column<int>(nullable: false),
                    total_pings = table.Column<int>(nullable: false),
                    lag_sd_ms = table.Column<int>(nullable: false),
                    lag_min_ms = table.Column<int>(nullable: false),
                    lag_max_ms = table.Column<int>(nullable: false),
                    lag_median_ms = table.Column<int>(nullable: false),
                    day = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aggregated_machine_pings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "log",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    device_id = table.Column<string>(nullable: true),
                    log_level = table.Column<string>(nullable: true),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    message = table.Column<string>(nullable: true),
                    server_timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    serial = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "machine_events",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    device_id = table.Column<string>(nullable: false),
                    event_type = table.Column<string>(nullable: false),
                    note = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    device_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_machine_events", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "machine_pings",
                columns: table => new
                {
                    device_id = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    device_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_device_id", x => x.device_id);
                    table.UniqueConstraint("AK_machine_pings_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "one_time_passes",
                columns: table => new
                {
                    token = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("one_time_passes_pkey", x => x.token);
                    table.UniqueConstraint("AK_one_time_passes_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pairing_tokens",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    token = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pairing_tokens", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "server_events",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    event_type = table.Column<string>(nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_server_events", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "support_logs",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    device_id = table.Column<string>(nullable: true),
                    timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_support_logs", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trades",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    crypto_code = table.Column<string>(nullable: false),
                    crypto_atoms = table.Column<decimal>(type: "numeric(30,0)", nullable: false),
                    fiat_code = table.Column<string>(nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    error = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trades", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_config",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<string>(nullable: false),
                    data = table.Column<string>(type: "json", nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    valid = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_config", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user_tokens",
                columns: table => new
                {
                    token = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("user_tokens_pkey", x => x.token);
                    table.UniqueConstraint("AK_user_tokens_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "devices",
                columns: table => new
                {
                    device_id = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false),
                    cashbox = table.Column<int>(nullable: false),
                    cassette1 = table.Column<int>(nullable: false),
                    cassette2 = table.Column<int>(nullable: false),
                    paired = table.Column<bool>(nullable: false, defaultValueSql: "true"),
                    display = table.Column<bool>(nullable: false, defaultValueSql: "true"),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    user_config_id = table.Column<int>(nullable: true),
                    name = table.Column<string>(nullable: false),
                    last_online = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    location = table.Column<string>(type: "json", nullable: false, defaultValueSql: "'{}'::json")
                },
                constraints: table =>
                {
                    table.PrimaryKey("devices_pkey", x => x.device_id);
                    table.UniqueConstraint("AK_devices_Id", x => x.Id);
                    table.ForeignKey(
                        name: "user_config_id",
                        column: x => x.user_config_id,
                        principalTable: "user_config",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    phone = table.Column<string>(nullable: true),
                    phone_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    id_card_data_number = table.Column<string>(nullable: true),
                    id_card_data_expiration = table.Column<DateTime>(type: "date", nullable: true),
                    id_card_data = table.Column<string>(type: "json", nullable: true),
                    id_card_data_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    name = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    sanctions = table.Column<bool>(nullable: true),
                    front_camera_path = table.Column<string>(nullable: true),
                    front_camera_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    id_card_photo_path = table.Column<string>(nullable: true),
                    id_card_photo_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    sms_override_by = table.Column<string>(nullable: true),
                    sms_override_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    id_card_data_override_by = table.Column<string>(nullable: true),
                    id_card_data_override_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    id_card_photo_override_by = table.Column<string>(nullable: true),
                    id_card_photo_override_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    front_camera_override_by = table.Column<string>(nullable: true),
                    front_camera_override_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    sanctions_override_by = table.Column<string>(nullable: true),
                    sanctions_override_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    authorized_override_by = table.Column<string>(nullable: true),
                    authorized_override_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    authorized_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    sanctions_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                    table.ForeignKey(
                        name: "customers_authorized_override_by_fkey",
                        column: x => x.authorized_override_by,
                        principalTable: "user_tokens",
                        principalColumn: "token",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "customers_front_facing_cam_override_by_fkey",
                        column: x => x.front_camera_override_by,
                        principalTable: "user_tokens",
                        principalColumn: "token",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "customers_id_card_data_override_by_fkey",
                        column: x => x.id_card_data_override_by,
                        principalTable: "user_tokens",
                        principalColumn: "token",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "customers_id_card_photo_override_by_fkey",
                        column: x => x.id_card_photo_override_by,
                        principalTable: "user_tokens",
                        principalColumn: "token",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "customers_sanctions_check_override_by_fkey",
                        column: x => x.sanctions_override_by,
                        principalTable: "user_tokens",
                        principalColumn: "token",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "customers_sms_override_by_fkey",
                        column: x => x.sms_override_by,
                        principalTable: "user_tokens",
                        principalColumn: "token",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cash_in_txs",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    device_id = table.Column<string>(nullable: false),
                    to_address = table.Column<string>(nullable: false),
                    crypto_atoms = table.Column<decimal>(type: "numeric(30,0)", nullable: false),
                    crypto_code = table.Column<string>(nullable: false),
                    fiat = table.Column<decimal>(type: "numeric(14,5)", nullable: false),
                    fiat_code = table.Column<string>(nullable: false),
                    fee = table.Column<long>(nullable: true),
                    tx_hash = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    error = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    send = table.Column<bool>(nullable: false),
                    send_confirmed = table.Column<bool>(nullable: false),
                    timedout = table.Column<bool>(nullable: false),
                    send_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    error_code = table.Column<string>(nullable: true),
                    operator_completed = table.Column<bool>(nullable: false),
                    send_pending = table.Column<bool>(nullable: false),
                    cash_in_fee = table.Column<decimal>(type: "numeric(14,5)", nullable: false),
                    cash_in_fee_crypto = table.Column<decimal>(type: "numeric(30,0)", nullable: false),
                    minimum_tx = table.Column<int>(nullable: false),
                    customer_id = table.Column<Guid>(nullable: true, defaultValueSql: "'47ac1184-8102-11e7-9079-8f13a7117867'::uuid"),
                    tx_version = table.Column<int>(nullable: false),
                    terms_accepted = table.Column<bool>(nullable: false),
                    commission_percentage = table.Column<decimal>(type: "numeric(14,5)", nullable: true, defaultValueSql: "NULL::numeric"),
                    raw_ticker_price = table.Column<decimal>(type: "numeric(14,5)", nullable: true, defaultValueSql: "NULL::numeric"),
                    is_paper_wallet = table.Column<bool>(nullable: true, defaultValueSql: "false")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cash_in_txs", x => x.id);
                    table.ForeignKey(
                        name: "cash_in_txs_customer_id_fkey",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cash_out_txs",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    device_id = table.Column<string>(nullable: false),
                    to_address = table.Column<string>(nullable: false),
                    crypto_atoms = table.Column<decimal>(type: "numeric(30,0)", nullable: false),
                    crypto_code = table.Column<string>(nullable: false),
                    fiat = table.Column<decimal>(type: "numeric(14,5)", nullable: false),
                    fiat_code = table.Column<string>(nullable: false),
                    dispense = table.Column<bool>(nullable: false),
                    notified = table.Column<bool>(nullable: false),
                    redeem = table.Column<bool>(nullable: false),
                    phone = table.Column<string>(nullable: true),
                    error = table.Column<string>(nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    confirmed_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    hd_index = table.Column<int>(nullable: true),
                    swept = table.Column<bool>(nullable: false),
                    timedout = table.Column<bool>(nullable: false),
                    dispense_confirmed = table.Column<bool>(nullable: true, defaultValueSql: "false"),
                    provisioned_1 = table.Column<int>(nullable: true),
                    provisioned_2 = table.Column<int>(nullable: true),
                    denomination_1 = table.Column<int>(nullable: true),
                    denomination_2 = table.Column<int>(nullable: true),
                    error_code = table.Column<string>(nullable: true),
                    customer_id = table.Column<Guid>(nullable: true, defaultValueSql: "'47ac1184-8102-11e7-9079-8f13a7117867'::uuid"),
                    tx_version = table.Column<int>(nullable: false),
                    published_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    terms_accepted = table.Column<bool>(nullable: false),
                    layer_2_address = table.Column<string>(nullable: true),
                    commission_percentage = table.Column<decimal>(type: "numeric(14,5)", nullable: true, defaultValueSql: "NULL::numeric"),
                    raw_ticker_price = table.Column<decimal>(type: "numeric(14,5)", nullable: true, defaultValueSql: "NULL::numeric")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cash_out_txs", x => x.id);
                    table.ForeignKey(
                        name: "cash_out_txs_customer_id_fkey",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "compliance_overrides",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    customer_id = table.Column<Guid>(nullable: true),
                    override_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    override_by = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compliance_overrides", x => x.id);
                    table.ForeignKey(
                        name: "compliance_authorizations_customer_id_fkey",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "compliance_authorizations_authorized_by_fkey",
                        column: x => x.override_by,
                        principalTable: "user_tokens",
                        principalColumn: "token",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "sanctions_logs",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    device_id = table.Column<string>(nullable: false),
                    sanctioned_id = table.Column<string>(nullable: false),
                    sanctioned_alias_id = table.Column<string>(nullable: true),
                    sanctioned_alias_full_name = table.Column<string>(nullable: false),
                    customer_id = table.Column<Guid>(nullable: false),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sanctions_logs", x => x.id);
                    table.ForeignKey(
                        name: "sanctions_logs_customer_id_fkey",
                        column: x => x.customer_id,
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "blacklist_crypto_code_address_key",
                table: "blacklist",
                columns: new[] { "crypto_code", "address" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cash_in_txs_customer_id",
                table: "cash_in_txs",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_cash_out_txs_customer_id",
                table: "cash_out_txs",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "cash_out_txs_hd_index_idx",
                table: "cash_out_txs",
                column: "hd_index",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_compliance_overrides_customer_id",
                table: "compliance_overrides",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_compliance_overrides_override_by",
                table: "compliance_overrides",
                column: "override_by");

            migrationBuilder.CreateIndex(
                name: "IX_customers_authorized_override_by",
                table: "customers",
                column: "authorized_override_by");

            migrationBuilder.CreateIndex(
                name: "IX_customers_front_camera_override_by",
                table: "customers",
                column: "front_camera_override_by");

            migrationBuilder.CreateIndex(
                name: "IX_customers_id_card_data_override_by",
                table: "customers",
                column: "id_card_data_override_by");

            migrationBuilder.CreateIndex(
                name: "IX_customers_id_card_photo_override_by",
                table: "customers",
                column: "id_card_photo_override_by");

            migrationBuilder.CreateIndex(
                name: "customers_phone_key",
                table: "customers",
                column: "phone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_sanctions_override_by",
                table: "customers",
                column: "sanctions_override_by");

            migrationBuilder.CreateIndex(
                name: "IX_customers_sms_override_by",
                table: "customers",
                column: "sms_override_by");

            migrationBuilder.CreateIndex(
                name: "IX_devices_user_config_id",
                table: "devices",
                column: "user_config_id");

            migrationBuilder.CreateIndex(
                name: "u_device_id",
                table: "machine_pings",
                column: "device_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sanctions_logs_customer_id",
                table: "sanctions_logs",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "server_events_created_idx",
                table: "server_events",
                column: "created");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aggregated_machine_pings");

            migrationBuilder.DropTable(
                name: "cash_in_txs");

            migrationBuilder.DropTable(
                name: "cash_out_txs");

            migrationBuilder.DropTable(
                name: "compliance_overrides");

            migrationBuilder.DropTable(
                name: "devices");

            migrationBuilder.DropTable(
                name: "logs");

            migrationBuilder.DropTable(
                name: "machine_events");

            migrationBuilder.DropTable(
                name: "machine_pings");

            migrationBuilder.DropTable(
                name: "one_time_passes");

            migrationBuilder.DropTable(
                name: "pairing_tokens");

            migrationBuilder.DropTable(
                name: "sanctions_logs");

            migrationBuilder.DropTable(
                name: "server_events");

            migrationBuilder.DropTable(
                name: "support_logs");

            migrationBuilder.DropTable(
                name: "trades");

            migrationBuilder.DropTable(
                name: "user_config");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "user_tokens");

            migrationBuilder.DropIndex(
                name: "blacklist_crypto_code_address_key",
                table: "blacklist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bills",
                table: "bills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cash_out_refills",
                table: "cash_out_refills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cash_out_actions",
                table: "cash_out_actions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cash_in_refills",
                table: "cash_in_refills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cash_in_actions",
                table: "cash_in_actions");

            migrationBuilder.RenameTable(
                name: "blacklist",
                newName: "Blacklist");

            migrationBuilder.RenameTable(
                name: "bills",
                newName: "Bill");

            migrationBuilder.RenameTable(
                name: "cash_out_refills",
                newName: "CashOutRefill");

            migrationBuilder.RenameTable(
                name: "cash_out_actions",
                newName: "CashOutAction");

            migrationBuilder.RenameTable(
                name: "cash_in_refills",
                newName: "CashInRefill");

            migrationBuilder.RenameTable(
                name: "cash_in_actions",
                newName: "CashInAction");

            migrationBuilder.RenameColumn(
                name: "address",
                table: "Blacklist",
                newName: "Address");

            migrationBuilder.RenameColumn(
                name: "crypto_code",
                table: "Blacklist",
                newName: "CryptoCode");

            migrationBuilder.RenameColumn(
                name: "created_by_operator",
                table: "Blacklist",
                newName: "CreatedByOperator");

            migrationBuilder.RenameColumn(
                name: "fiat",
                table: "Bill",
                newName: "Fiat");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "Bill",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Bill",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "fiat_code",
                table: "Bill",
                newName: "FiatCode");

            migrationBuilder.RenameColumn(
                name: "device_time",
                table: "Bill",
                newName: "DeviceTime");

            migrationBuilder.RenameColumn(
                name: "crypto_code",
                table: "Bill",
                newName: "CryptoCode");

            migrationBuilder.RenameColumn(
                name: "crypto_atoms_after_fee",
                table: "Bill",
                newName: "CryptoAtomsAfterFee");

            migrationBuilder.RenameColumn(
                name: "crypto_atoms",
                table: "Bill",
                newName: "CryptoAtoms");

            migrationBuilder.RenameColumn(
                name: "cash_in_txs_id",
                table: "Bill",
                newName: "CashInTxsId");

            migrationBuilder.RenameColumn(
                name: "cash_in_fee_crypto",
                table: "Bill",
                newName: "CashInFeeCrypto");

            migrationBuilder.RenameColumn(
                name: "cash_in_fee",
                table: "Bill",
                newName: "CashInFee");

            migrationBuilder.RenameColumn(
                name: "denomination2",
                table: "CashOutRefill",
                newName: "Denomination2");

            migrationBuilder.RenameColumn(
                name: "denomination1",
                table: "CashOutRefill",
                newName: "Denomination1");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "CashOutRefill",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "cassette2",
                table: "CashOutRefill",
                newName: "Cassette2");

            migrationBuilder.RenameColumn(
                name: "cassette1",
                table: "CashOutRefill",
                newName: "Cassette1");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CashOutRefill",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "CashOutRefill",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "device_id",
                table: "CashOutRefill",
                newName: "DeviceId");

            migrationBuilder.RenameColumn(
                name: "redeem",
                table: "CashOutAction",
                newName: "Redeem");

            migrationBuilder.RenameColumn(
                name: "error",
                table: "CashOutAction",
                newName: "Error");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "CashOutAction",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "action",
                table: "CashOutAction",
                newName: "Action");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CashOutAction",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "tx_id",
                table: "CashOutAction",
                newName: "TxId");

            migrationBuilder.RenameColumn(
                name: "tx_hash",
                table: "CashOutAction",
                newName: "TxHash");

            migrationBuilder.RenameColumn(
                name: "to_address",
                table: "CashOutAction",
                newName: "ToAddress");

            migrationBuilder.RenameColumn(
                name: "rejected_2",
                table: "CashOutAction",
                newName: "Rejected2");

            migrationBuilder.RenameColumn(
                name: "rejected_1",
                table: "CashOutAction",
                newName: "Rejected1");

            migrationBuilder.RenameColumn(
                name: "provisioned_2",
                table: "CashOutAction",
                newName: "Provisioned2");

            migrationBuilder.RenameColumn(
                name: "provisioned_1",
                table: "CashOutAction",
                newName: "Provisioned1");

            migrationBuilder.RenameColumn(
                name: "layer_2_address",
                table: "CashOutAction",
                newName: "Layer2Address");

            migrationBuilder.RenameColumn(
                name: "error_code",
                table: "CashOutAction",
                newName: "ErrorCode");

            migrationBuilder.RenameColumn(
                name: "dispensed_2",
                table: "CashOutAction",
                newName: "Dispensed2");

            migrationBuilder.RenameColumn(
                name: "dispensed_1",
                table: "CashOutAction",
                newName: "Dispensed1");

            migrationBuilder.RenameColumn(
                name: "device_time",
                table: "CashOutAction",
                newName: "DeviceTime");

            migrationBuilder.RenameColumn(
                name: "device_id",
                table: "CashOutAction",
                newName: "DeviceId");

            migrationBuilder.RenameColumn(
                name: "denomination_2",
                table: "CashOutAction",
                newName: "Denomination2");

            migrationBuilder.RenameColumn(
                name: "denomination_1",
                table: "CashOutAction",
                newName: "Denomination1");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "CashInRefill",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CashInRefill",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "CashInRefill",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "device_id",
                table: "CashInRefill",
                newName: "DeviceId");

            migrationBuilder.RenameColumn(
                name: "cash_box_count",
                table: "CashInRefill",
                newName: "CashBoxCount");

            migrationBuilder.RenameColumn(
                name: "error",
                table: "CashInAction",
                newName: "Error");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "CashInAction",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "action",
                table: "CashInAction",
                newName: "Action");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "CashInAction",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "tx_id",
                table: "CashInAction",
                newName: "TxId");

            migrationBuilder.RenameColumn(
                name: "tx_hash",
                table: "CashInAction",
                newName: "TxHash");

            migrationBuilder.RenameColumn(
                name: "error_code",
                table: "CashInAction",
                newName: "ErrorCode");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:cash_out_action_types", "published,authorized,instant,confirmed,rejected,insufficientFunds,dispenseRequested,dispensed,notified,addedPhone,redeem")
                .OldAnnotation("Npgsql:Enum:compliance_type", "authorized,sms,id_card_data,id_card_photo,sanctions,front_camera,hard_limit")
                .OldAnnotation("Npgsql:Enum:status_stage", "notSeen,published,authorized,instant,confirmed,rejected,insufficientFunds")
                .OldAnnotation("Npgsql:Enum:trade_type", "buy,sell")
                .OldAnnotation("Npgsql:Enum:transaction_authority", "timeout,machine,pending,rejected,published,authorized,confirmed")
                .OldAnnotation("Npgsql:Enum:transaction_stage", "initial_request,partial_request,final_request,partial_send,deposit,dispense_request,dispense")
                .OldAnnotation("Npgsql:Enum:verification_type", "verified,blocked,automatic");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Blacklist",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Blacklist",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CryptoCode",
                table: "Blacklist",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<bool>(
                name: "CreatedByOperator",
                table: "Blacklist",
                type: "boolean",
                nullable: true,
                oldClrType: typeof(bool),
                oldDefaultValueSql: "true");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Bill",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<string>(
                name: "FiatCode",
                table: "Bill",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CryptoCode",
                table: "Bill",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true,
                oldDefaultValueSql: "'BTC'::text");

            migrationBuilder.AlterColumn<decimal>(
                name: "CryptoAtomsAfterFee",
                table: "Bill",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(30,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CryptoAtoms",
                table: "Bill",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(30,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CashInFeeCrypto",
                table: "Bill",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(30,0)");

            migrationBuilder.AlterColumn<decimal>(
                name: "CashInFee",
                table: "Bill",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(14,5)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "CashOutRefill",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceId",
                table: "CashOutRefill",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "CashOutAction",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "CashOutAction",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DeviceId",
                table: "CashOutAction",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldDefaultValueSql: "''::text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "CashInRefill",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<string>(
                name: "DeviceId",
                table: "CashInRefill",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "CashInAction",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "now()");

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "CashInAction",
                type: "text",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Blacklist",
                table: "Blacklist",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bills",
                table: "Bill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashOutRefills",
                table: "CashOutRefill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashOutActions",
                table: "CashOutAction",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashInRefills",
                table: "CashInRefill",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CashInActions",
                table: "CashInAction",
                column: "Id");
        }
    }
}
