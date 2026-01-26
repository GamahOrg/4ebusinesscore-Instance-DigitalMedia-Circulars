using Microsoft.Extensions.Configuration;

namespace Circulars.Infrastructure.Context
{
    public class ContextSeed
    {
        private static DBContext _dbContext;
        private static IServiceProvider _serviceProvider;

        public static void Seed(DBContext appDbContext, IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _dbContext = appDbContext;
            _dbContext.Database.EnsureCreated();
            _serviceProvider = serviceProvider;

            SeedIssuers();
            SeedEnforcement();
            SeedApproval();

            bool isSeedEnabled = configuration.GetSection("IsSeedData").Get<bool>();
            if (isSeedEnabled)
            {
                SeedCircularPrivate();
            }
        }
        private static void SetMissingForeignKeys(object entity, DbContext context)
        {
            var entityType = context.Model.FindEntityType(entity.GetType());
            if (entityType == null) return;

            foreach (var foreignKey in entityType.GetForeignKeys())
            {
                var principalEntityType = foreignKey.PrincipalEntityType;
                var dependentProps = foreignKey.Properties;

                if (dependentProps.Count != 1)
                    continue; // فقط المفاتيح الفردية

                var fkProperty = dependentProps[0];
                var propInfo = entity.GetType().GetProperty(fkProperty.Name);
                if (propInfo == null)
                    continue;

                var currentValue = propInfo.GetValue(entity);

                // استخدم reflection للوصول إلى DbContext.Set<T>()
                var setMethod = typeof(DbContext)
                    .GetMethod("Set", Type.EmptyTypes)
                    ?.MakeGenericMethod(principalEntityType.ClrType);

                if (setMethod == null)
                    continue;

                var dbSet = setMethod.Invoke(context, null);
                if (dbSet == null)
                    continue;

                var idProperty = principalEntityType.ClrType.GetProperty("Id");
                if (idProperty == null)
                    continue;

                // خذ أول ID موجود في الجدول
                var firstItem = ((IQueryable)dbSet).Cast<object>().FirstOrDefault();
                var firstId = firstItem != null ? idProperty.GetValue(firstItem) : null;

                var dbSetList = ((IQueryable)dbSet).Cast<object>().ToList();
                var exists = currentValue != null &&
                             dbSetList.Any(x =>
                             {
                                 var value = idProperty.GetValue(x);
                                 return value != null && value.Equals(currentValue);
                             });


                // لو null أو مش موجود → استبداله
                if (!exists && firstId != null)
                {
                    propInfo.SetValue(entity, firstId);
                }
            }
        }
        private static void SeedIssuers()
        {
            string IssuersJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "IssuersSeedData.json");
            var Issuers = JsonConvert.DeserializeObject<List<Domain.Models.LK_Issuer>>(IssuersJson);

            if (Issuers != null && Issuers.Any())
            {
                _dbContext.Database.OpenConnection();
                try
                {
                    if (!_dbContext.Issuers.Any())
                    {
                        foreach (var Issuer in Issuers)
                        {
                            Issuer.CreatedOn = DateTime.Now;
                        }

                        _dbContext.Issuers.AddRange(Issuers);
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        var existingIssuers = _dbContext.Issuers.ToList();
                        var newIssuers = Issuers
                            .Where(nk => existingIssuers.Any(ek => ek.NameEn == nk.NameEn))
                            .ToList();

                        if (!newIssuers.Any())
                        {
                            foreach (var Issuer in newIssuers)
                            {
                                Issuer.CreatedOn = DateTime.Now;
                            }

                            _dbContext.Issuers.AddRange(newIssuers);
                            _dbContext.SaveChanges();
                        }
                    }
                }
                finally
                {
                    _dbContext.Database.CloseConnection();
                }
            }
        }
        private static void SeedEnforcement()
        {
            string EnforcementsJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "EnforcementsSeedData.json");
            var Enforcements = JsonConvert.DeserializeObject<List<Domain.Models.LK_Enforcement>>(EnforcementsJson);

            if (Enforcements != null && Enforcements.Any())
            {
                _dbContext.Database.OpenConnection();
                try
                {
                    if (!_dbContext.Enforcements.Any())
                    {
                        foreach (var Enforcement in Enforcements)
                        {
                            Enforcement.CreatedOn = DateTime.Now;
                        }

                        _dbContext.Enforcements.AddRange(Enforcements);
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        var existingEnforcements = _dbContext.Enforcements.ToList();
                        var newEnforcements = Enforcements
                            .Where(nk => existingEnforcements.Any(ek => ek.NameEn == nk.NameEn))
                            .ToList();

                        if (!newEnforcements.Any())
                        {
                            foreach (var Enforcement in newEnforcements)
                            {
                                Enforcement.CreatedOn = DateTime.Now;
                            }

                            _dbContext.Enforcements.AddRange(newEnforcements);
                            _dbContext.SaveChanges();
                        }
                    }
                }
                finally
                {
                    _dbContext.Database.CloseConnection();
                }
            }
        }
        private static void SeedApproval()
        {
            string ApprovalsJson = File.ReadAllText(@"SeedData" + Path.DirectorySeparatorChar + "ApprovalsSeedData.json");
            var Approvals = JsonConvert.DeserializeObject<List<Domain.Models.LK_Approval>>(ApprovalsJson);

            if (Approvals != null && Approvals.Any())
            {
                _dbContext.Database.OpenConnection();
                try
                {
                    if (!_dbContext.Approvals.Any())
                    {
                        foreach (var Approval in Approvals)
                        {
                            Approval.CreatedOn = DateTime.Now;
                        }

                        _dbContext.Approvals.AddRange(Approvals);
                        _dbContext.SaveChanges();
                    }
                    else
                    {
                        var existingApprovals = _dbContext.Approvals.ToList();
                        Approvals.ForEach(x =>
                        {
                            var approve = existingApprovals.FirstOrDefault(n => n.Id == x.Id);
                            if (approve != null)
                            {
                                approve.NameEn = x.NameEn;
                                approve.NameAr = x.NameAr;
                                _dbContext.Approvals.Update(approve);

                            }
                            else
                            {
                                x.CreatedOn = DateTime.Now;
                                _dbContext.Approvals.Add(x);
                            }

                        });
                        _dbContext.SaveChanges();
                         existingApprovals = _dbContext.Approvals.ToList();
                        var repeatedApprovals = existingApprovals.Where(x=> Approvals.Any(a=>a.NameEn.ToLower().Contains(x.NameEn.ToLower()) 
                        && a.NameAr.Contains(x.NameAr))).ToList();
                        var newVariable = repeatedApprovals.Where(x => !Approvals.Any(a => a.Id == x.Id)).ToList();
                        if (newVariable.Any())
                        {
                            var cir = _dbContext.Circular.ToList();
                            cir = cir.Where(x => newVariable.Any(n => n.Id == x.ApprovalId)).ToList();
                            cir.ForEach(x =>
                            {
                                var app = existingApprovals.FirstOrDefault(n=>n.Id == x.ApprovalId);
                                var newapp = Approvals.FirstOrDefault(a => a.NameEn == app.NameEn);
                                x.ApprovalId = newapp.Id;
                                _dbContext.Circular.Update(x);
                                _dbContext.SaveChanges();
                            });
                            _dbContext.Approvals.RemoveRange(newVariable);
                            _dbContext.SaveChanges();
                        }
                        
                        // 
                        //var newApprovals = Approvals
                        //    .Where(nk => !existingApprovals.Any(ek => ek.NameEn == nk.NameEn))
                        //    .ToList();

                        //if (newApprovals.Any())
                        //{
                        //    foreach (var Approval in newApprovals)
                        //    {
                        //        Approval.CreatedOn = DateTime.Now;
                        //    }

                        //    _dbContext.Approvals.AddRange(newApprovals);
                        //    _dbContext.SaveChanges();
                        //}
                    }
                }
                finally
                {
                    _dbContext.Database.CloseConnection();
                }
            }
        }
        private static void SeedCircularPrivate()
        {
            var filePath = Path.Combine("SeedData", "CircularPrivateSeedData.json");

            if (!File.Exists(filePath))
                return;

            var json = File.ReadAllText(filePath);
            var circulars = JsonConvert.DeserializeObject<List<Circular>>(json);

            if (circulars is not { Count: > 0 } || _dbContext.Circular.Any())
                return;

            var now = DateTime.Now;
            var defaultUserId = Guid.Parse("3eb17e81-ede8-4b02-90a1-3625e695af03");

            foreach (var circular in circulars)
            {
                circular.CreatedOn = now;
                circular.CreatedBy = defaultUserId;

                SetMissingForeignKeys(circular, _dbContext);

                circular.Attachments?.ForEach(a =>
                {
                    a.CreatedOn = now;
                    a.CreatedBy = defaultUserId;
                    SetMissingForeignKeys(a, _dbContext);
                });

                circular.RelatedDocuments?.ForEach(r =>
                {
                    r.CreatedOn = now;
                    r.CreatedBy = defaultUserId;
                    SetMissingForeignKeys(r, _dbContext);
                });

                circular.Orgs?.ForEach(o =>
                {
                    o.CreatedOn = now;
                    o.CreatedBy = defaultUserId;
                    SetMissingForeignKeys(o, _dbContext);
                });

                circular.OrgsConcerned?.ForEach(o =>
                {
                    o.CreatedOn = now;
                    o.CreatedBy = defaultUserId;
                    SetMissingForeignKeys(o, _dbContext);
                });

                circular.Users?.ForEach(u =>
                {
                    u.CreatedOn = now;
                    u.CreatedBy = defaultUserId;
                    SetMissingForeignKeys(u, _dbContext);
                });
            }

            try
            {
                _dbContext.Circular.AddRange(circulars);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during seeding circulars: " + ex.Message);
                throw;
            }
        }

    }
}
