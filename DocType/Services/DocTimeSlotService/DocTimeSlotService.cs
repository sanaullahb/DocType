using DocType.Data;
using DocType.Models;
using DocType.Services.DocTimeSlotService.DTO;
using DocType.Services.DocTimeSlotService.DTO.Request;
using DocType.Services.DocTimeSlotService.DTO.Response;

namespace DocType.Services.DocTimeSlotService
{
        public class DocTimeSlotService : IDocTimeSlotService
        {
            private readonly AppDbContext _context;

            public DocTimeSlotService(AppDbContext context)
            {
                _context = context;
            }

        // 1️⃣ Generate Slots from Availability
        public async Task<bool> GenerateSlotsAsync(string availabilityId, CancellationToken cancellationToken)
        {
            var availability = _context.DocAvailabilities
                .FirstOrDefault(x => x.Id == availabilityId && x.IsActive);

            if (availability == null)
                return false;

            var time = availability.StartTime;

            while (time < availability.EndTime)
            {
                bool exists = _context.DocTimeSlot.Any(x =>
                    x.DoctorId == availability.DoctorId &&
                    x.Date == availability.AvailableDate &&
                    x.Time == time);

                if (!exists)
                {
                    var slot = new DocTimeSlot
                    {
                        Id = Guid.NewGuid().ToString(),
                        DoctorId = availability.DoctorId,
                        Date = availability.AvailableDate,
                        Time = time,
                        IsBooked = false,
                        AvailabilityId = availability.Id,

                        CreatedBy = "system",
                        UpdatedBy = "system",
                        CreatedDate = DateTime.UtcNow,
                        UpdatedDate = DateTime.UtcNow,
                        IsActive = true,
                        IsArchived = false
                    };

                    await _context.DocTimeSlot.AddAsync(slot, cancellationToken);
                }

                time = time.AddMinutes(availability.SlotDurationMinutes);
            }

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        // 2️⃣ Get Slots
        public async Task<IEnumerable<ResponseDocTimeSlot>> GetSlotsByDoctorAndDateAsync(
                string doctorId,
                DateOnly date,
                CancellationToken cancellationToken)
            {
                var slots =  _context.DocTimeSlot
                    .Where(x => x.DoctorId == doctorId && x.Date == date && x.IsActive)
                    .OrderBy(x => x.Time)
                    .ToList();

                return slots.Select(x => x.ToResponse());
            }

            // 3️⃣ Book Slot
            public async Task<bool> BookSlotAsync(
                RequestBookDocTimeSlot request,
                string userId,
                CancellationToken cancellationToken)
            {
                var slot =  _context.DocTimeSlot
                    .FirstOrDefault(x => x.Id == request.SlotId && x.IsActive);

                if (slot == null || slot.IsBooked)
                    return false;

                slot.IsBooked = true;
                slot.UpdatedDate = DateTime.UtcNow;
                slot.UpdatedBy = userId;

                _context.DocTimeSlot.Update(slot);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }

            // 4️⃣ Cancel Booking
            public async Task<bool> CancelSlotAsync(string slotId, CancellationToken cancellationToken)
            {
                var slot =  _context.DocTimeSlot
                    .FirstOrDefault(x => x.Id == slotId && x.IsActive);

                if (slot == null || !slot.IsBooked)
                    return false;

                slot.IsBooked = false;
                slot.UpdatedDate = DateTime.UtcNow;

                _context.DocTimeSlot.Update(slot);
                await _context.SaveChangesAsync(cancellationToken);

                return true;
            }
        
    }
}
