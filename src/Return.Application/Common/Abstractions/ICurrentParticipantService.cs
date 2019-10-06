﻿// ******************************************************************************
//  © 2019 Sebastiaan Dammann | damsteen.nl
// 
//  File:           : ICurrentParticipantService.cs
//  Project         : Return.Application
// ******************************************************************************

namespace Return.Application.Common.Abstractions {
    using System.Threading.Tasks;

    public interface ICurrentParticipantService {
        Task<int> GetParticipantId();

        Task<bool> IsManager();
    }
}
