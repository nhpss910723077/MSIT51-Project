using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Security.Principal;

namespace MSIT51BT_ASP.Models {
    public class CommonDateTimeSaveChangesInterceptor : SaveChangesInterceptor {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result) {
            SetEntityDateTime(eventData);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData, InterceptionResult<int> result,
            CancellationToken cancellationToken = new CancellationToken()
        ) {
            SetEntityDateTime(eventData);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void SetEntityDateTime(DbContextEventData eventData) {
            if (eventData.Context == null) return;
            var entries = eventData.Context.ChangeTracker.Entries();
            foreach (var entry in entries) {
                if (entry.Entity is not ICommonDateTime entity) continue;

                if (entry.State == EntityState.Added) {
                    entity.UpdateTime = DateTime.Now;
                    entity.CreateTime = DateTime.Now;
                }
                else if (entry.State == EntityState.Modified) {
                    entity.UpdateTime = DateTime.Now;
                }
            }
        }
    }
}
