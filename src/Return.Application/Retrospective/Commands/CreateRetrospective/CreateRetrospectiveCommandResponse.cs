﻿// ******************************************************************************
//  © 2019 Sebastiaan Dammann | damsteen.nl
// 
//  File:           : CreateRetrospectiveCommandResponse.cs
//  Project         : Return.Application
// ******************************************************************************

namespace Return.Application.Retrospective.Commands.CreateRetrospective {
    using Domain.ValueObjects;
    using QRCoder;

    public sealed class CreateRetrospectiveCommandResponse {
        public RetroIdentifier Identifier { get; }
        public QrCode QrCode { get; }

        public CreateRetrospectiveCommandResponse(RetroIdentifier identifier, QrCode qrCode) {
            this.Identifier = identifier;
            this.QrCode = qrCode;
        }
    }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1815:Override equals and operator equals on value types", Justification = "<Pending>")]
    public readonly struct QrCode {
        private readonly QRCodeData _qrCodeData;

        public QrCode(QRCodeData qrCodeData) {
            this._qrCodeData = qrCodeData;
        }

        public string ToBase64() {
            using var base64QrCode = new Base64QRCode(this._qrCodeData);

            return base64QrCode.GetGraphic(30);
        }
    }
}