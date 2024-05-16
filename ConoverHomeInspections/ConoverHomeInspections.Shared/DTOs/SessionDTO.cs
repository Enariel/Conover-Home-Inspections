// ConoverHomeInspections
// SessionDTO.cs
//  2024
// Oliver Conover
// Modified: 15-05-2024
using System.Net;

namespace ConoverHomeInspections.Shared
{
    public record SessionDTO(Guid sessionId, string device, IPAddress IpAddress, DateTime createdOn, DateTime expires, bool isActive, bool isExpired, bool isLocked, bool isBanned);
}