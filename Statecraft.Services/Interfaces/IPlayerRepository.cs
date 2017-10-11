using Statecraft.Common.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statecraft.Services.Interfaces
{
    public interface IPlayerRepository
    {
        PlayerDto GetPlayerById(Guid playerId);
    }
}
