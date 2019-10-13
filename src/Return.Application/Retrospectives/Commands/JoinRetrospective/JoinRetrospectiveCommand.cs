﻿// ******************************************************************************
//  © 2019 Sebastiaan Dammann | damsteen.nl
// 
//  File:           : JoinRetrospectiveCommand.cs
//  Project         : Return.Application
// ******************************************************************************

namespace Return.Application.Retrospectives.Commands.JoinRetrospective {
    using MediatR;
    using Queries.GetParticipantsInfo;

#nullable disable

    public sealed class JoinRetrospectiveCommand : IRequest<ParticipantInfo> {
        public string Name { get; set; }
        public string Color { get; set; }

        public string Passphrase { get; set; }

        public bool JoiningAsManager { get; set; }
        public string RetroId { get; set; }
    }
}