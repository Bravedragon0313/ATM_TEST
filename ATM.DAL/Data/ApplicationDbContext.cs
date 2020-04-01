using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using ATM.BL.Models;
using System.IO;

namespace ATM.DAL.Data
{
    /// <summary>
    /// ApplicationDbContext
    /// </summary>
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<CustomerToken> UserTokens { get; set; }

        public virtual DbSet<Log> Logs { get; set; }

        public virtual DbSet<Device> Devices { get; set; }
        public virtual DbSet<DeviceConfig> DeviceConfig { get; set; }
        public virtual DbSet<PairingToken> PairingTokens { get; set; }
        public virtual DbSet<MachineEvent> MachineEvents { get; set; }
        public virtual DbSet<MachinePing> MachinePings { get; set; }
        public virtual DbSet<AggregatedMachinePing> AggregatedMachinePings { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<AuthenticationMessage> AuthenticationMessages { get; set; }

        public virtual DbSet<Bill> Bills { get; set; }

        public virtual DbSet<CashInAction> CashInActions { get; set; }
        public virtual DbSet<CashInRefill> CashInRefills { get; set; }
        public virtual DbSet<CashInTx> CashInTxs { get; set; }

        public virtual DbSet<CashOutAction> CashOutActions { get; set; }
        public virtual DbSet<CashOutRefill> CashOutRefills { get; set; }
        public virtual DbSet<CashOutTx> CashOutTxs { get; set; }

        public virtual DbSet<ComplianceOverride> ComplianceOverrides { get; set; }

        public virtual DbSet<SanctionsLog> SanctionsLogs { get; set; }
        public virtual DbSet<ServerEvent> ServerEvents { get; set; }

        public virtual DbSet<Trade> Trades { get; set; }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile(@Directory.GetCurrentDirectory() + "appsettings.json")
                    .Build();
                var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
                var connectionString = configuration.GetConnectionString("DatabaseConnection");
                builder.UseNpgsql(connectionString);
                return new ApplicationDbContext(builder.Options);
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresEnum(null, "cash_out_action_types", new[] { "published", "authorized", "instant", "confirmed", "rejected", "insufficientFunds", "dispenseRequested", "dispensed", "notified", "addedPhone", "redeem" })
                .HasPostgresEnum(null, "compliance_type", new[] { "authorized", "sms", "id_card_data", "id_card_photo", "sanctions", "front_camera", "hard_limit" })
                .HasPostgresEnum(null, "status_stage", new[] { "notSeen", "published", "authorized", "instant", "confirmed", "rejected", "insufficientFunds" })
                .HasPostgresEnum(null, "trade_type", new[] { "buy", "sell" })
                .HasPostgresEnum(null, "transaction_authority", new[] { "timeout", "machine", "pending", "rejected", "published", "authorized", "confirmed" })
                .HasPostgresEnum(null, "transaction_stage", new[] { "initial_request", "partial_request", "final_request", "partial_send", "deposit", "dispense_request", "dispense" })
                .HasPostgresEnum(null, "verification_type", new[] { "verified", "blocked", "automatic" });

            modelBuilder.Entity<AggregatedMachinePing>(entity =>
            {
                entity.ToTable("aggregated_machine_pings");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Day)
                    .HasColumnName("day")
                    .HasColumnType("date");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasColumnName("device_id");

                entity.Property(e => e.DroppedPings).HasColumnName("dropped_pings");

                entity.Property(e => e.LagMaxMs).HasColumnName("lag_max_ms");

                entity.Property(e => e.LagMedianMs).HasColumnName("lag_median_ms");

                entity.Property(e => e.LagMinMs).HasColumnName("lag_min_ms");

                entity.Property(e => e.LagSdMs).HasColumnName("lag_sd_ms");

                entity.Property(e => e.TotalPings).HasColumnName("total_pings");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.ToTable("bills");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CashInFee)
                    .HasColumnName("cash_in_fee")
                    .HasColumnType("numeric(14,5)");

                entity.Property(e => e.CashInFeeCrypto)
                    .HasColumnName("cash_in_fee_crypto")
                    .HasColumnType("numeric(30,0)");

                entity.Property(e => e.CashInTxsId).HasColumnName("cash_in_txs_id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CryptoAtoms)
                    .HasColumnName("crypto_atoms")
                    .HasColumnType("numeric(30,0)");

                entity.Property(e => e.CryptoAtomsAfterFee)
                    .HasColumnName("crypto_atoms_after_fee")
                    .HasColumnType("numeric(30,0)");

                entity.Property(e => e.CryptoCode)
                    .HasColumnName("crypto_code")
                    .HasDefaultValueSql("'BTC'::text");

                entity.Property(e => e.DeviceTime).HasColumnName("device_time");

                entity.Property(e => e.Fiat).HasColumnName("fiat");

                entity.Property(e => e.FiatCode)
                    .IsRequired()
                    .HasColumnName("fiat_code");
            });

            modelBuilder.Entity<CashInAction>(entity =>
                {
                    entity.ToTable("cash_in_actions");

                    entity.Property(e => e.Id).HasColumnName("id");

                    entity.Property(e => e.Action)
                        .IsRequired()
                        .HasColumnName("action");

                    entity.Property(e => e.Created)
                        .HasColumnName("created")
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("now()");

                    entity.Property(e => e.Error).HasColumnName("error");

                    entity.Property(e => e.ErrorCode).HasColumnName("error_code");

                    entity.Property(e => e.TxHash).HasColumnName("tx_hash");

                    entity.Property(e => e.TxId).HasColumnName("tx_id");
                });

            modelBuilder.Entity<CashInRefill>(entity =>
            {
                entity.ToTable("cash_in_refills");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CashBoxCount).HasColumnName("cash_box_count");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasColumnName("device_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<AuthenticationMessage>(entity =>
                {
                    entity.ToTable("authentication_message");

                    entity.Property(e => e.Id)
                        .HasColumnName("id")
                        .ValueGeneratedNever();

                    entity.HasOne(e => e.Device);

                    entity.Property(x => x.IsUsed).HasColumnName("is_used").HasDefaultValue("false");

                    entity.Property(e => e.DateCreated)
                            .HasColumnName("DateCreated")
                            .HasColumnType("timestamp with time zone")
                            .HasDefaultValueSql("now()");

                    entity.Property(e => e.Data)
                        .IsRequired()
                        .HasColumnName("Data");

                    entity.HasOne(d => d.Customer)
                            .WithMany(p => p.AuthenticationMessage)
                            .HasForeignKey(d => d.Id)
                            .HasConstraintName("am_id_fkey");
                });

            modelBuilder.Entity<CashInTx>(entity =>
            {
                entity.ToTable("cash_in_txs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CashInFee)
                    .HasColumnName("cash_in_fee")
                    .HasColumnType("numeric(14,5)");

                entity.Property(e => e.CashInFeeCrypto)
                    .HasColumnName("cash_in_fee_crypto")
                    .HasColumnType("numeric(30,0)");

                entity.Property(e => e.CommissionPercentage)
                    .HasColumnName("commission_percentage")
                    .HasColumnType("numeric(14,5)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CryptoAtoms)
                    .HasColumnName("crypto_atoms")
                    .HasColumnType("numeric(30,0)");

                entity.Property(e => e.CryptoCode)
                    .IsRequired()
                    .HasColumnName("crypto_code");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasColumnName("device_id");

                entity.Property(e => e.Error).HasColumnName("error");

                entity.Property(e => e.ErrorCode).HasColumnName("error_code");

                entity.Property(e => e.Fee).HasColumnName("fee");

                entity.Property(e => e.Fiat)
                    .HasColumnName("fiat")
                    .HasColumnType("numeric(14,5)");

                entity.Property(e => e.FiatCode)
                    .IsRequired()
                    .HasColumnName("fiat_code");

                entity.Property(e => e.IsPaperWallet)
                    .HasColumnName("is_paper_wallet")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.MinimumTx).HasColumnName("minimum_tx");

                entity.Property(e => e.OperatorCompleted).HasColumnName("operator_completed");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.RawTickerPrice)
                    .HasColumnName("raw_ticker_price")
                    .HasColumnType("numeric(14,5)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.Send).HasColumnName("send");

                entity.Property(e => e.SendConfirmed).HasColumnName("send_confirmed");

                entity.Property(e => e.SendPending).HasColumnName("send_pending");

                entity.Property(e => e.SendTime)
                    .HasColumnName("send_time")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.TermsAccepted).HasColumnName("terms_accepted");

                entity.Property(e => e.Timedout).HasColumnName("timedout");

                entity.Property(e => e.ToAddress)
                    .IsRequired()
                    .HasColumnName("to_address");

                entity.Property(e => e.TxHash).HasColumnName("tx_hash");

                entity.Property(e => e.TxVersion).HasColumnName("tx_version");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CashInTxs)
                    .HasConstraintName("cash_in_txs_customer_id_fkey");
            });

            modelBuilder.Entity<CashOutAction>(entity =>
            {
                entity.ToTable("cash_out_actions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Action)
                    .IsRequired()
                    .HasColumnName("action");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Denomination1).HasColumnName("denomination_1");

                entity.Property(e => e.Denomination2).HasColumnName("denomination_2");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasColumnName("device_id")
                    .HasDefaultValueSql("''::text");

                entity.Property(e => e.DeviceTime).HasColumnName("device_time");

                entity.Property(e => e.Dispensed1).HasColumnName("dispensed_1");

                entity.Property(e => e.Dispensed2).HasColumnName("dispensed_2");

                entity.Property(e => e.Error).HasColumnName("error");

                entity.Property(e => e.ErrorCode).HasColumnName("error_code");

                entity.Property(e => e.Layer2Address).HasColumnName("layer_2_address");

                entity.Property(e => e.Provisioned1).HasColumnName("provisioned_1");

                entity.Property(e => e.Provisioned2).HasColumnName("provisioned_2");

                entity.Property(e => e.Redeem).HasColumnName("redeem");

                entity.Property(e => e.Rejected1).HasColumnName("rejected_1");

                entity.Property(e => e.Rejected2).HasColumnName("rejected_2");

                entity.Property(e => e.ToAddress).HasColumnName("to_address");

                entity.Property(e => e.TxHash).HasColumnName("tx_hash");

                entity.Property(e => e.TxId).HasColumnName("tx_id");
            });

            modelBuilder.Entity<CashOutRefill>(entity =>
            {
                entity.ToTable("cash_out_refills");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cassette1).HasColumnName("cassette1");

                entity.Property(e => e.Cassette2).HasColumnName("cassette2");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Denomination1).HasColumnName("denomination1");

                entity.Property(e => e.Denomination2).HasColumnName("denomination2");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasColumnName("device_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<CashOutTx>(entity =>
            {
                entity.ToTable("cash_out_txs");

                entity.HasIndex(e => e.HdIndex)
                    .HasName("cash_out_txs_hd_index_idx")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CommissionPercentage)
                    .HasColumnName("commission_percentage")
                    .HasColumnType("numeric(14,5)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.ConfirmedAt)
                    .HasColumnName("confirmed_at")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CryptoAtoms)
                    .HasColumnName("crypto_atoms")
                    .HasColumnType("numeric(30,0)");

                entity.Property(e => e.CryptoCode)
                    .IsRequired()
                    .HasColumnName("crypto_code");

                entity.Property(e => e.Denomination1).HasColumnName("denomination_1");

                entity.Property(e => e.Denomination2).HasColumnName("denomination_2");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasColumnName("device_id");

                entity.Property(e => e.Dispense).HasColumnName("dispense");

                entity.Property(e => e.DispenseConfirmed)
                    .HasColumnName("dispense_confirmed")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.Error).HasColumnName("error");

                entity.Property(e => e.ErrorCode).HasColumnName("error_code");

                entity.Property(e => e.Fiat)
                    .HasColumnName("fiat")
                    .HasColumnType("numeric(14,5)");

                entity.Property(e => e.FiatCode)
                    .IsRequired()
                    .HasColumnName("fiat_code");

                entity.Property(e => e.HdIndex).HasColumnName("hd_index");

                entity.Property(e => e.Layer2Address).HasColumnName("layer_2_address");

                entity.Property(e => e.Notified).HasColumnName("notified");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.Provisioned1).HasColumnName("provisioned_1");

                entity.Property(e => e.Provisioned2).HasColumnName("provisioned_2");

                entity.Property(e => e.PublishedAt)
                    .HasColumnName("published_at")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.RawTickerPrice)
                    .HasColumnName("raw_ticker_price")
                    .HasColumnType("numeric(14,5)")
                    .HasDefaultValueSql("NULL::numeric");

                entity.Property(e => e.Redeem).HasColumnName("redeem");

                entity.Property(e => e.Swept).HasColumnName("swept");

                entity.Property(e => e.TermsAccepted).HasColumnName("terms_accepted");

                entity.Property(e => e.Timedout).HasColumnName("timedout");

                entity.Property(e => e.ToAddress)
                    .IsRequired()
                    .HasColumnName("to_address");

                entity.Property(e => e.TxVersion).HasColumnName("tx_version");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CashOutTxs)
                    .HasConstraintName("cash_out_txs_customer_id_fkey");
            });

            modelBuilder.Entity<ComplianceOverride>(entity =>
            {
                entity.ToTable("compliance_overrides");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.OverrideAt)
                    .HasColumnName("override_at")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.OverrideBy).HasColumnName("override_by");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ComplianceOverrides)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("compliance_authorizations_customer_id_fkey");

                entity.HasOne(d => d.OverrideByNavigation)
                    .WithMany(p => p.ComplianceOverrides)
                    .HasForeignKey(d => d.OverrideBy)
                    .HasConstraintName("compliance_authorizations_authorized_by_fkey");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("customers");

                entity.HasIndex(e => e.Phone)
                    .HasName("customers_phone_key")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.AuthorizedAt)
                    .HasColumnName("authorized_at")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.AuthorizedOverrideAt)
                    .HasColumnName("authorized_override_at")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.AuthorizedOverrideBy).HasColumnName("authorized_override_by");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FrontCameraAt)
                    .HasColumnName("front_camera_at")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.FrontCameraOverrideAt)
                    .HasColumnName("front_camera_override_at")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.FrontCameraOverrideBy).HasColumnName("front_camera_override_by");

                entity.Property(e => e.FrontCameraPath).HasColumnName("front_camera_path");

                entity.Property(e => e.IdCardData)
                    .HasColumnName("id_card_data")
                    .HasColumnType("json");

                entity.Property(e => e.IdCardDataAt)
                    .HasColumnName("id_card_data_at")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.IdCardDataExpiration)
                    .HasColumnName("id_card_data_expiration")
                    .HasColumnType("date");

                entity.Property(e => e.IdCardDataNumber).HasColumnName("id_card_data_number");

                entity.Property(e => e.IdCardDataOverrideAt)
                    .HasColumnName("id_card_data_override_at")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.IdCardDataOverrideBy).HasColumnName("id_card_data_override_by");

                entity.Property(e => e.IdCardPhotoAt)
                    .HasColumnName("id_card_photo_at")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.IdCardPhotoOverrideAt)
                    .HasColumnName("id_card_photo_override_at")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.IdCardPhotoOverrideBy).HasColumnName("id_card_photo_override_by");

                entity.Property(e => e.IdCardPhotoPath).HasColumnName("id_card_photo_path");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Phone).HasColumnName("phone");

                entity.Property(e => e.PhoneAt)
                    .HasColumnName("phone_at")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Sanctions).HasColumnName("sanctions");

                entity.Property(e => e.SanctionsAt)
                    .HasColumnName("sanctions_at")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.SanctionsOverrideAt)
                    .HasColumnName("sanctions_override_at")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.SanctionsOverrideBy).HasColumnName("sanctions_override_by");

                entity.Property(e => e.SmsOverrideAt)
                    .HasColumnName("sms_override_at")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.SmsOverrideBy).HasColumnName("sms_override_by");

                entity.HasOne(d => d.AuthorizedOverrideByNavigation)
                    .WithMany(p => p.CustomersAuthorizedOverrideByNavigation)
                    .HasForeignKey(d => d.AuthorizedOverrideBy)
                    .HasConstraintName("customers_authorized_override_by_fkey");

                entity.HasOne(d => d.FrontCameraOverrideByNavigation)
                    .WithMany(p => p.CustomersFrontCameraOverrideByNavigation)
                    .HasForeignKey(d => d.FrontCameraOverrideBy)
                    .HasConstraintName("customers_front_facing_cam_override_by_fkey");

                entity.HasOne(d => d.IdCardDataOverrideByNavigation)
                    .WithMany(p => p.CustomersIdCardDataOverrideByNavigation)
                    .HasForeignKey(d => d.IdCardDataOverrideBy)
                    .HasConstraintName("customers_id_card_data_override_by_fkey");

                entity.HasOne(d => d.IdCardPhotoOverrideByNavigation)
                    .WithMany(p => p.CustomersIdCardPhotoOverrideByNavigation)
                    .HasForeignKey(d => d.IdCardPhotoOverrideBy)
                    .HasConstraintName("customers_id_card_photo_override_by_fkey");

                entity.HasOne(d => d.SanctionsOverrideByNavigation)
                    .WithMany(p => p.CustomersSanctionsOverrideByNavigation)
                    .HasForeignKey(d => d.SanctionsOverrideBy)
                    .HasConstraintName("customers_sanctions_check_override_by_fkey");

                entity.HasOne(d => d.SmsOverrideByNavigation)
                    .WithMany(p => p.CustomersSmsOverrideByNavigation)
                    .HasForeignKey(d => d.SmsOverrideBy)
                    .HasConstraintName("customers_sms_override_by_fkey");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.DeviceId)
                    .HasName("devices_pkey");

                entity.ToTable("device");

                entity.Property(e => e.DeviceId).HasColumnName("device_id");

                entity.Property(e => e.Cashbox).HasColumnName("cashbox");

                entity.Property(e => e.Cassette1).HasColumnName("cassette1");

                entity.Property(e => e.Cassette2).HasColumnName("cassette2");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Display)
                    .IsRequired()
                    .HasColumnName("display")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.LastOnline)
                    .HasColumnName("last_online")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasColumnType("json")
                    .HasDefaultValueSql("'{}'::json");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Paired)
                    .IsRequired()
                    .HasColumnName("paired")
                    .HasDefaultValueSql("true");

                entity.Property(e => e.UserConfigId).HasColumnName("device_config_id");

                entity.HasOne(d => d.DeviceConfig)
                    .WithMany(p => p.Devices)
                    .HasForeignKey(d => d.UserConfigId)
                    .HasConstraintName("device_config_id");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable("log");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DeviceId).HasColumnName("device_id");

                entity.Property(e => e.LogLevel).HasColumnName("log_level");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Serial).HasColumnName("serial");

                entity.Property(e => e.ServerTimestamp)
                    .HasColumnName("server_timestamp")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Timestamp)
                    .HasColumnName("timestamp")
                    .HasColumnType("timestamp with time zone");
            });

            modelBuilder.Entity<MachineEvent>(entity =>
            {
                entity.ToTable("machine_events");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasColumnName("device_id");

                entity.Property(e => e.DeviceTime)
                    .HasColumnName("device_time")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.EventType)
                    .IsRequired()
                    .HasColumnName("event_type");

                entity.Property(e => e.Note).HasColumnName("note");
            });

            modelBuilder.Entity<MachinePing>(entity =>
            {
                entity.HasKey(e => e.DeviceId)
                    .HasName("pk_device_id");

                entity.ToTable("machine_pings");

                entity.HasIndex(e => e.DeviceId)
                    .HasName("u_device_id")
                    .IsUnique();

                entity.Property(e => e.DeviceId).HasColumnName("device_id");

                entity.Property(e => e.DeviceTime)
                    .HasColumnName("device_time")
                    .HasColumnType("timestamp with time zone");

                entity.Property(e => e.Updated)
                    .HasColumnName("updated")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<PairingToken>(entity =>
            {
                entity.ToTable("pairing_tokens");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Token).HasColumnName("token");
            });

            modelBuilder.Entity<SanctionsLog>(entity =>
            {
                entity.ToTable("sanctions_logs");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.DeviceId)
                    .IsRequired()
                    .HasColumnName("device_id");

                entity.Property(e => e.SanctionedAliasFullName)
                    .IsRequired()
                    .HasColumnName("sanctioned_alias_full_name");

                entity.Property(e => e.SanctionedAliasId).HasColumnName("sanctioned_alias_id");

                entity.Property(e => e.SanctionedId)
                    .IsRequired()
                    .HasColumnName("sanctioned_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.SanctionsLogs)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sanctions_logs_customer_id_fkey");
            });

            modelBuilder.Entity<ServerEvent>(entity =>
            {
                entity.ToTable("server_events");

                entity.HasIndex(e => e.Created)
                    .HasName("server_events_created_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.EventType)
                    .IsRequired()
                    .HasColumnName("event_type");
            });

            modelBuilder.Entity<Trade>(entity =>
            {
                entity.ToTable("trades");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CryptoAtoms)
                    .HasColumnName("crypto_atoms")
                    .HasColumnType("numeric(30,0)");

                entity.Property(e => e.CryptoCode)
                    .IsRequired()
                    .HasColumnName("crypto_code");

                entity.Property(e => e.Error).HasColumnName("error");

                entity.Property(e => e.FiatCode)
                    .IsRequired()
                    .HasColumnName("fiat_code");
            });

            modelBuilder.Entity<DeviceConfig>(entity =>
            {
                entity.ToTable("device_config");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Data)
                    .IsRequired()
                    .HasColumnName("data")
                    .HasColumnType("json");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type");

                entity.Property(e => e.Valid).HasColumnName("valid");
            });

            modelBuilder.Entity<CustomerToken>(entity =>
            {
                entity.HasKey(e => e.Token)
                    .HasName("user_tokens_pkey");

                entity.ToTable("user_tokens");

                entity.Property(e => e.Token).HasColumnName("token");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("timestamp with time zone")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
