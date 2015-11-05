﻿using System;

namespace Lte.Domain.ZipLib.Zip
{
    public enum CompressionMethod
    {
        BZip2 = 11,
        Deflate64 = 9,
        Deflated = 8,
        Stored = 0,
        WinZipAES = 0x63
    }

    public enum EncryptionAlgorithm
    {
        Aes128 = 0x660e,
        Aes192 = 0x660f,
        Aes256 = 0x6610,
        Blowfish = 0x6720,
        Des = 0x6601,
        None = 0,
        PkzipClassic = 1,
        RC2 = 0x6602,
        RC2Corrected = 0x6702,
        RC4 = 0x6801,
        TripleDes112 = 0x6609,
        TripleDes168 = 0x6603,
        Twofish = 0x6721,
        Unknown = 0xffff
    }

    public enum FileUpdateMode
    {
        Safe,
        Direct
    }

    [Flags]
    public enum GeneralBitFlags
    {
        Descriptor = 8,
        Encrypted = 1,
        EnhancedCompress = 0x1000,
        HeaderMasked = 0x2000,
        Method = 6,
        Patched = 0x20,
        ReservedPkware14 = 0x4000,
        ReservedPkware15 = 0x8000,
        ReservedPKware4 = 0x10,
        StrongEncryption = 0x40,
        UnicodeText = 0x800,
        Unused10 = 0x400,
        Unused7 = 0x80,
        Unused8 = 0x100,
        Unused9 = 0x200
    }

    public enum HostSystemID
    {
        AcornRisc = 13,
        AlternateMvs = 15,
        Amiga = 1,
        AtariST = 5,
        BeOS = 0x10,
        Cpm = 9,
        Macintosh = 7,
        Msdos = 0,
        MVS = 11,
        OpenVms = 2,
        OS2 = 6,
        OS400 = 0x12,
        OSX = 0x13,
        Tandem = 0x11,
        Unix = 3,
        Vfat = 14,
        VMCms = 4,
        Vse = 12,
        WindowsNT = 10,
        WinZipAES = 0x63,
        ZSystem = 8
    }

    public enum TestOperation
    {
        Initialising,
        EntryHeader,
        EntryData,
        EntryComplete,
        MiscellaneousTests,
        Complete
    }

    public enum TestStrategy
    {
        FindFirstError,
        FindAllErrors
    }

    public enum UseZip64
    {
        Off,
        On,
        Dynamic
    }

    public delegate void ZipTestResultHandler(TestStatus status, string message);

}
