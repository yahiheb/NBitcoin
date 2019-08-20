using System;

namespace NBitcoin.Altcoins.HashX11.Crypto.SHA3
{
	internal class Shabal224 : Shabal
	{
		public Shabal224()
			: base(NBitcoin.Altcoins.HashX11.HashSize.HashSize224)
		{
		}
	}

	internal class Shabal256 : Shabal
	{
		public Shabal256()
			: base(NBitcoin.Altcoins.HashX11.HashSize.HashSize256)
		{
		}
	}

	internal class Shabal384 : Shabal
	{
		public Shabal384()
			: base(NBitcoin.Altcoins.HashX11.HashSize.HashSize384)
		{
		}
	}

	internal class Shabal512 : Shabal
	{
		public Shabal512()
			: base(NBitcoin.Altcoins.HashX11.HashSize.HashSize512)
		{
		}
	}

	internal abstract class Shabal : BlockHash, ICryptoNotBuildIn
	{
		#region Consts
		private static readonly uint[] s_A_init_224 =
		{
			0xA5201467, 0xA9B8D94A, 0xD4CED997, 0x68379D7B,
			0xA7FC73BA, 0xF1A2546B, 0x606782BF, 0xE0BCFD0F,
			0x2F25374E, 0x069A149F, 0x5E2DFF25, 0xFAECF061
		};

		private static readonly uint[] s_B_init_224 =
		{
			0xEC9905D8, 0xF21850CF, 0xC0A746C8, 0x21DAD498,
			0x35156EEB, 0x088C97F2, 0x26303E40, 0x8A2D4FB5,
			0xFEEE44B6, 0x8A1E9573, 0x7B81111A, 0xCBC139F0,
			0xA3513861, 0x1D2C362E, 0x918C580E, 0xB58E1B9C
		};

		private static readonly uint[] s_C_init_224 =
		{
			0xE4B573A1, 0x4C1A0880, 0x1E907C51, 0x04807EFD,
			0x3AD8CDE5, 0x16B21302, 0x02512C53, 0x2204CB18,
			0x99405F2D, 0xE5B648A1, 0x70AB1D43, 0xA10C25C2,
			0x16F1AC05, 0x38BBEB56, 0x9B01DC60, 0xB1096D83
		};

		private static readonly uint[] s_A_init_256 =
		{
			0x52F84552, 0xE54B7999, 0x2D8EE3EC, 0xB9645191,
			0xE0078B86, 0xBB7C44C9, 0xD2B5C1CA, 0xB0D2EB8C,
			0x14CE5A45, 0x22AF50DC, 0xEFFDBC6B, 0xEB21B74A
		};

		private static readonly uint[] s_B_init_256 =
		{
			0xB555C6EE, 0x3E710596, 0xA72A652F, 0x9301515F,
			0xDA28C1FA, 0x696FD868, 0x9CB6BF72, 0x0AFE4002,
			0xA6E03615, 0x5138C1D4, 0xBE216306, 0xB38B8890,
			0x3EA8B96B, 0x3299ACE4, 0x30924DD4, 0x55CB34A5
		};

		private static readonly uint[] s_C_init_256 =
		{
			0xB405F031, 0xC4233EBA, 0xB3733979, 0xC0DD9D55,
			0xC51C28AE, 0xA327B8E1, 0x56C56167, 0xED614433,
			0x88B59D60, 0x60E2CEBA, 0x758B4B8B, 0x83E82A7F,
			0xBC968828, 0xE6E00BF7, 0xBA839E55, 0x9B491C60
		};

		private static readonly uint[] s_A_init_384 =
		{
			0xC8FCA331, 0xE55C504E, 0x003EBF26, 0xBB6B8D83,
			0x7B0448C1, 0x41B82789, 0x0A7C9601, 0x8D659CFF,
			0xB6E2673E, 0xCA54C77B, 0x1460FD7E, 0x3FCB8F2D
		};

		private static readonly uint[] s_B_init_384 =
		{
			0x527291FC, 0x2A16455F, 0x78E627E5, 0x944F169F,
			0x1CA6F016, 0xA854EA25, 0x8DB98ABE, 0xF2C62641,
			0x30117DCB, 0xCF5C4309, 0x93711A25, 0xF9F671B8,
			0xB01D2116, 0x333F4B89, 0xB285D165, 0x86829B36
		};

		private static readonly uint[] s_C_init_384 =
		{
			0xF764B11A, 0x76172146, 0xCEF6934D, 0xC6D28399,
			0xFE095F61, 0x5E6018B4, 0x5048ECF5, 0x51353261,
			0x6E6E36DC, 0x63130DAD, 0xA9C69BD6, 0x1E90EA0C,
			0x7C35073B, 0x28D95E6D, 0xAA340E0D, 0xCB3DEE70
		};

		private static readonly uint[] s_A_init_512 =
		{
			0x20728DFD, 0x46C0BD53, 0xE782B699, 0x55304632,
			0x71B4EF90, 0x0EA9E82C, 0xDBB930F1, 0xFAD06B8B,
			0xBE0CAE40, 0x8BD14410, 0x76D2ADAC, 0x28ACAB7F
		};

		private static readonly uint[] s_B_init_512 =
		{
			0xC1099CB7, 0x07B385F3, 0xE7442C26, 0xCC8AD640,
			0xEB6F56C7, 0x1EA81AA9, 0x73B9D314, 0x1DE85D08,
			0x48910A5A, 0x893B22DB, 0xC5A0DF44, 0xBBC4324E,
			0x72D2F240, 0x75941D99, 0x6D8BDE82, 0xA1A7502B
		};

		private static readonly uint[] s_C_init_512 =
		{
			0xD9BF68D1, 0x58BAD750, 0x56028CB2, 0x8134F359,
			0xB5D469D8, 0x941A8CC2, 0x418B2A6E, 0x04052780,
			0x7F07D787, 0x5194358F, 0x3C60D665, 0xBE97D79A,
			0x950C3434, 0xAED9A06D, 0x2537DC8D, 0x7CDB5969
		};

		#endregion

		private readonly uint[] m_A = new uint[12];
		private readonly uint[] m_B = new uint[16];
		private readonly uint[] m_C = new uint[16];

		public Shabal(NBitcoin.Altcoins.HashX11.HashSize a_hash_size)
			: base((int)a_hash_size, 64)
		{
			Initialize();
		}

		protected override void TransformBlock(byte[] a_data, int a_index)
		{
			uint A00, A01, A02, A03, A04, A05, A06, A07, A08, A09, A0A, A0B;
			uint B0, B1, B2, B3, B4, B5, B6, B7, B8, B9, BA, BB, BC, BD, BE, BF;
			uint C0, C1, C2, C3, C4, C5, C6, C7, C8, C9, CA, CB, CC, CD, CE, CF;
			uint M0, M1, M2, M3, M4, M5, M6, M7, M8, M9, MA, MB, MC, MD, ME, MF;
			uint tmp;

			uint[] data = new uint[16];
			Converters.ConvertBytesToUInts(a_data, a_index, BlockSize, data);

			A00 = m_A[0];
			A01 = m_A[1];
			A02 = m_A[2];
			A00 = m_A[0];
			A01 = m_A[1];
			A02 = m_A[2];
			A03 = m_A[3];
			A04 = m_A[4];
			A05 = m_A[5];
			A06 = m_A[6];
			A07 = m_A[7];
			A08 = m_A[8];
			A09 = m_A[9];
			A0A = m_A[10];
			A0B = m_A[11];

			B0 = m_B[0];
			B1 = m_B[1];
			B2 = m_B[2];
			B3 = m_B[3];
			B4 = m_B[4];
			B5 = m_B[5];
			B6 = m_B[6];
			B7 = m_B[7];
			B8 = m_B[8];
			B9 = m_B[9];
			BA = m_B[10];
			BB = m_B[11];
			BC = m_B[12];
			BD = m_B[13];
			BE = m_B[14];
			BF = m_B[15];

			C0 = m_C[0];
			C1 = m_C[1];
			C2 = m_C[2];
			C3 = m_C[3];
			C4 = m_C[4];
			C5 = m_C[5];
			C6 = m_C[6];
			C7 = m_C[7];
			C8 = m_C[8];
			C9 = m_C[9];
			CA = m_C[10];
			CB = m_C[11];
			CC = m_C[12];
			CD = m_C[13];
			CE = m_C[14];
			CF = m_C[15];

			M0 = data[0];
			M1 = data[1];
			M2 = data[2];
			M3 = data[3];
			M4 = data[4];
			M5 = data[5];
			M6 = data[6];
			M7 = data[7];
			M8 = data[8];
			M9 = data[9];
			MA = data[10];
			MB = data[11];
			MC = data[12];
			MD = data[13];
			ME = data[14];
			MF = data[15];

			B0 = B0 + M0;
			B1 = B1 + M1;
			B2 = B2 + M2;
			B3 = B3 + M3;
			B4 = B4 + M4;
			B5 = B5 + M5;
			B6 = B6 + M6;
			B7 = B7 + M7;
			B8 = B8 + M8;
			B9 = B9 + M9;
			BA = BA + MA;
			BB = BB + MB;
			BC = BC + MC;
			BD = BD + MD;
			BE = BE + ME;
			BF = BF + MF;

			ulong blocks = m_processed_bytes / (uint)BlockSize;

			A00 ^= (uint)blocks;
			A01 ^= (uint)(blocks >> 32);

			B0 = (B0 << 17) | (B0 >> 15);
			B1 = (B1 << 17) | (B1 >> 15);
			B2 = (B2 << 17) | (B2 >> 15);
			B3 = (B3 << 17) | (B3 >> 15);
			B4 = (B4 << 17) | (B4 >> 15);
			B5 = (B5 << 17) | (B5 >> 15);
			B6 = (B6 << 17) | (B6 >> 15);
			B7 = (B7 << 17) | (B7 >> 15);
			B8 = (B8 << 17) | (B8 >> 15);
			B9 = (B9 << 17) | (B9 >> 15);
			BA = (BA << 17) | (BA >> 15);
			BB = (BB << 17) | (BB >> 15);
			BC = (BC << 17) | (BC >> 15);
			BD = (BD << 17) | (BD >> 15);
			BE = (BE << 17) | (BE >> 15);
			BF = (BF << 17) | (BF >> 15);

			A00 = ((A00 ^ (((A0B << 15) | (A0B >> 17)) * 5) ^ C8) * 3) ^ BD ^ (B9 & ~B6) ^ M0;
			B0 = ~(((B0 << 1) | (B0 >> 31)) ^ A00);
			A01 = ((A01 ^ (((A00 << 15) | (A00 >> 17)) * 5) ^ C7) * 3) ^ BE ^ (BA & ~B7) ^ M1;
			B1 = ~(((B1 << 1) | (B1 >> 31)) ^ A01);
			A02 = ((A02 ^ (((A01 << 15) | (A01 >> 17)) * 5) ^ C6) * 3) ^ BF ^ (BB & ~B8) ^ M2;
			B2 = ~(((B2 << 1) | (B2 >> 31)) ^ A02);
			A03 = ((A03 ^ (((A02 << 15) | (A02 >> 17)) * 5) ^ C5) * 3) ^ B0 ^ (BC & ~B9) ^ M3;
			B3 = ~(((B3 << 1) | (B3 >> 31)) ^ A03);
			A04 = ((A04 ^ (((A03 << 15) | (A03 >> 17)) * 5) ^ C4) * 3) ^ B1 ^ (BD & ~BA) ^ M4;
			B4 = ~(((B4 << 1) | (B4 >> 31)) ^ A04);
			A05 = ((A05 ^ (((A04 << 15) | (A04 >> 17)) * 5) ^ C3) * 3) ^ B2 ^ (BE & ~BB) ^ M5;
			B5 = ~(((B5 << 1) | (B5 >> 31)) ^ A05);
			A06 = ((A06 ^ (((A05 << 15) | (A05 >> 17)) * 5) ^ C2) * 3) ^ B3 ^ (BF & ~BC) ^ M6;
			B6 = ~(((B6 << 1) | (B6 >> 31)) ^ A06);
			A07 = ((A07 ^ (((A06 << 15) | (A06 >> 17)) * 5) ^ C1) * 3) ^ B4 ^ (B0 & ~BD) ^ M7;
			B7 = ~(((B7 << 1) | (B7 >> 31)) ^ A07);
			A08 = ((A08 ^ (((A07 << 15) | (A07 >> 17)) * 5) ^ C0) * 3) ^ B5 ^ (B1 & ~BE) ^ M8;
			B8 = ~(((B8 << 1) | (B8 >> 31)) ^ A08);
			A09 = ((A09 ^ (((A08 << 15) | (A08 >> 17)) * 5) ^ CF) * 3) ^ B6 ^ (B2 & ~BF) ^ M9;
			B9 = ~(((B9 << 1) | (B9 >> 31)) ^ A09);
			A0A = ((A0A ^ (((A09 << 15) | (A09 >> 17)) * 5) ^ CE) * 3) ^ B7 ^ (B3 & ~B0) ^ MA;
			BA = ~(((BA << 1) | (BA >> 31)) ^ A0A);
			A0B = ((A0B ^ (((A0A << 15) | (A0A >> 17)) * 5) ^ CD) * 3) ^ B8 ^ (B4 & ~B1) ^ MB;
			BB = ~(((BB << 1) | (BB >> 31)) ^ A0B);
			A00 = ((A00 ^ (((A0B << 15) | (A0B >> 17)) * 5) ^ CC) * 3) ^ B9 ^ (B5 & ~B2) ^ MC;
			BC = ~(((BC << 1) | (BC >> 31)) ^ A00);
			A01 = ((A01 ^ (((A00 << 15) | (A00 >> 17)) * 5) ^ CB) * 3) ^ BA ^ (B6 & ~B3) ^ MD;
			BD = ~(((BD << 1) | (BD >> 31)) ^ A01);
			A02 = ((A02 ^ (((A01 << 15) | (A01 >> 17)) * 5) ^ CA) * 3) ^ BB ^ (B7 & ~B4) ^ ME;
			BE = ~(((BE << 1) | (BE >> 31)) ^ A02);
			A03 = ((A03 ^ (((A02 << 15) | (A02 >> 17)) * 5) ^ C9) * 3) ^ BC ^ (B8 & ~B5) ^ MF;
			BF = ~(((BF << 1) | (BF >> 31)) ^ A03);
			A04 = ((A04 ^ (((A03 << 15) | (A03 >> 17)) * 5) ^ C8) * 3) ^ BD ^ (B9 & ~B6) ^ M0;
			B0 = ~(((B0 << 1) | (B0 >> 31)) ^ A04);
			A05 = ((A05 ^ (((A04 << 15) | (A04 >> 17)) * 5) ^ C7) * 3) ^ BE ^ (BA & ~B7) ^ M1;
			B1 = ~(((B1 << 1) | (B1 >> 31)) ^ A05);
			A06 = ((A06 ^ (((A05 << 15) | (A05 >> 17)) * 5) ^ C6) * 3) ^ BF ^ (BB & ~B8) ^ M2;
			B2 = ~(((B2 << 1) | (B2 >> 31)) ^ A06);
			A07 = ((A07 ^ (((A06 << 15) | (A06 >> 17)) * 5) ^ C5) * 3) ^ B0 ^ (BC & ~B9) ^ M3;
			B3 = ~(((B3 << 1) | (B3 >> 31)) ^ A07);
			A08 = ((A08 ^ (((A07 << 15) | (A07 >> 17)) * 5) ^ C4) * 3) ^ B1 ^ (BD & ~BA) ^ M4;
			B4 = ~(((B4 << 1) | (B4 >> 31)) ^ A08);
			A09 = ((A09 ^ (((A08 << 15) | (A08 >> 17)) * 5) ^ C3) * 3) ^ B2 ^ (BE & ~BB) ^ M5;
			B5 = ~(((B5 << 1) | (B5 >> 31)) ^ A09);
			A0A = ((A0A ^ (((A09 << 15) | (A09 >> 17)) * 5) ^ C2) * 3) ^ B3 ^ (BF & ~BC) ^ M6;
			B6 = ~(((B6 << 1) | (B6 >> 31)) ^ A0A);
			A0B = ((A0B ^ (((A0A << 15) | (A0A >> 17)) * 5) ^ C1) * 3) ^ B4 ^ (B0 & ~BD) ^ M7;
			B7 = ~(((B7 << 1) | (B7 >> 31)) ^ A0B);
			A00 = ((A00 ^ (((A0B << 15) | (A0B >> 17)) * 5) ^ C0) * 3) ^ B5 ^ (B1 & ~BE) ^ M8;
			B8 = ~(((B8 << 1) | (B8 >> 31)) ^ A00);
			A01 = ((A01 ^ (((A00 << 15) | (A00 >> 17)) * 5) ^ CF) * 3) ^ B6 ^ (B2 & ~BF) ^ M9;
			B9 = ~(((B9 << 1) | (B9 >> 31)) ^ A01);
			A02 = ((A02 ^ (((A01 << 15) | (A01 >> 17)) * 5) ^ CE) * 3) ^ B7 ^ (B3 & ~B0) ^ MA;
			BA = ~(((BA << 1) | (BA >> 31)) ^ A02);
			A03 = ((A03 ^ (((A02 << 15) | (A02 >> 17)) * 5) ^ CD) * 3) ^ B8 ^ (B4 & ~B1) ^ MB;
			BB = ~(((BB << 1) | (BB >> 31)) ^ A03);
			A04 = ((A04 ^ (((A03 << 15) | (A03 >> 17)) * 5) ^ CC) * 3) ^ B9 ^ (B5 & ~B2) ^ MC;
			BC = ~(((BC << 1) | (BC >> 31)) ^ A04);
			A05 = ((A05 ^ (((A04 << 15) | (A04 >> 17)) * 5) ^ CB) * 3) ^ BA ^ (B6 & ~B3) ^ MD;
			BD = ~(((BD << 1) | (BD >> 31)) ^ A05);
			A06 = ((A06 ^ (((A05 << 15) | (A05 >> 17)) * 5) ^ CA) * 3) ^ BB ^ (B7 & ~B4) ^ ME;
			BE = ~(((BE << 1) | (BE >> 31)) ^ A06);
			A07 = ((A07 ^ (((A06 << 15) | (A06 >> 17)) * 5) ^ C9) * 3) ^ BC ^ (B8 & ~B5) ^ MF;
			BF = ~(((BF << 1) | (BF >> 31)) ^ A07);
			A08 = ((A08 ^ (((A07 << 15) | (A07 >> 17)) * 5) ^ C8) * 3) ^ BD ^ (B9 & ~B6) ^ M0;
			B0 = ~(((B0 << 1) | (B0 >> 31)) ^ A08);
			A09 = ((A09 ^ (((A08 << 15) | (A08 >> 17)) * 5) ^ C7) * 3) ^ BE ^ (BA & ~B7) ^ M1;
			B1 = ~(((B1 << 1) | (B1 >> 31)) ^ A09);
			A0A = ((A0A ^ (((A09 << 15) | (A09 >> 17)) * 5) ^ C6) * 3) ^ BF ^ (BB & ~B8) ^ M2;
			B2 = ~(((B2 << 1) | (B2 >> 31)) ^ A0A);
			A0B = ((A0B ^ (((A0A << 15) | (A0A >> 17)) * 5) ^ C5) * 3) ^ B0 ^ (BC & ~B9) ^ M3;
			B3 = ~(((B3 << 1) | (B3 >> 31)) ^ A0B);
			A00 = ((A00 ^ (((A0B << 15) | (A0B >> 17)) * 5) ^ C4) * 3) ^ B1 ^ (BD & ~BA) ^ M4;
			B4 = ~(((B4 << 1) | (B4 >> 31)) ^ A00);
			A01 = ((A01 ^ (((A00 << 15) | (A00 >> 17)) * 5) ^ C3) * 3) ^ B2 ^ (BE & ~BB) ^ M5;
			B5 = ~(((B5 << 1) | (B5 >> 31)) ^ A01);
			A02 = ((A02 ^ (((A01 << 15) | (A01 >> 17)) * 5) ^ C2) * 3) ^ B3 ^ (BF & ~BC) ^ M6;
			B6 = ~(((B6 << 1) | (B6 >> 31)) ^ A02);
			A03 = ((A03 ^ (((A02 << 15) | (A02 >> 17)) * 5) ^ C1) * 3) ^ B4 ^ (B0 & ~BD) ^ M7;
			B7 = ~(((B7 << 1) | (B7 >> 31)) ^ A03);
			A04 = ((A04 ^ (((A03 << 15) | (A03 >> 17)) * 5) ^ C0) * 3) ^ B5 ^ (B1 & ~BE) ^ M8;
			B8 = ~(((B8 << 1) | (B8 >> 31)) ^ A04);
			A05 = ((A05 ^ (((A04 << 15) | (A04 >> 17)) * 5) ^ CF) * 3) ^ B6 ^ (B2 & ~BF) ^ M9;
			B9 = ~(((B9 << 1) | (B9 >> 31)) ^ A05);
			A06 = ((A06 ^ (((A05 << 15) | (A05 >> 17)) * 5) ^ CE) * 3) ^ B7 ^ (B3 & ~B0) ^ MA;
			BA = ~(((BA << 1) | (BA >> 31)) ^ A06);
			A07 = ((A07 ^ (((A06 << 15) | (A06 >> 17)) * 5) ^ CD) * 3) ^ B8 ^ (B4 & ~B1) ^ MB;
			BB = ~(((BB << 1) | (BB >> 31)) ^ A07);
			A08 = ((A08 ^ (((A07 << 15) | (A07 >> 17)) * 5) ^ CC) * 3) ^ B9 ^ (B5 & ~B2) ^ MC;
			BC = ~(((BC << 1) | (BC >> 31)) ^ A08);
			A09 = ((A09 ^ (((A08 << 15) | (A08 >> 17)) * 5) ^ CB) * 3) ^ BA ^ (B6 & ~B3) ^ MD;
			BD = ~(((BD << 1) | (BD >> 31)) ^ A09);
			A0A = ((A0A ^ (((A09 << 15) | (A09 >> 17)) * 5) ^ CA) * 3) ^ BB ^ (B7 & ~B4) ^ ME;
			BE = ~(((BE << 1) | (BE >> 31)) ^ A0A);
			A0B = ((A0B ^ (((A0A << 15) | (A0A >> 17)) * 5) ^ C9) * 3) ^ BC ^ (B8 & ~B5) ^ MF;
			BF = ~(((BF << 1) | (BF >> 31)) ^ A0B);

			A0B = A0B + C6;
			A0A = A0A + C5;
			A09 = A09 + C4;
			A08 = A08 + C3;
			A07 = A07 + C2;
			A06 = A06 + C1;
			A05 = A05 + C0;
			A04 = A04 + CF;
			A03 = A03 + CE;
			A02 = A02 + CD;
			A01 = A01 + CC;
			A00 = A00 + CB;
			A0B = A0B + CA;
			A0A = A0A + C9;
			A09 = A09 + C8;
			A08 = A08 + C7;
			A07 = A07 + C6;
			A06 = A06 + C5;
			A05 = A05 + C4;
			A04 = A04 + C3;
			A03 = A03 + C2;
			A02 = A02 + C1;
			A01 = A01 + C0;
			A00 = A00 + CF;
			A0B = A0B + CE;
			A0A = A0A + CD;
			A09 = A09 + CC;
			A08 = A08 + CB;
			A07 = A07 + CA;
			A06 = A06 + C9;
			A05 = A05 + C8;
			A04 = A04 + C7;
			A03 = A03 + C6;
			A02 = A02 + C5;
			A01 = A01 + C4;
			A00 = A00 + C3;

			C0 = C0 - M0;
			C1 = C1 - M1;
			C2 = C2 - M2;
			C3 = C3 - M3;
			C4 = C4 - M4;
			C5 = C5 - M5;
			C6 = C6 - M6;
			C7 = C7 - M7;
			C8 = C8 - M8;
			C9 = C9 - M9;
			CA = CA - MA;
			CB = CB - MB;
			CC = CC - MC;
			CD = CD - MD;
			CE = CE - ME;
			CF = CF - MF;

			tmp = (B0);
			(B0) = (C0);
			(C0) = tmp;
			tmp = (B1);
			(B1) = (C1);
			(C1) = tmp;
			tmp = (B2);
			(B2) = (C2);
			(C2) = tmp;
			tmp = (B3);
			(B3) = (C3);
			(C3) = tmp;
			tmp = (B4);
			(B4) = (C4);
			(C4) = tmp;
			tmp = (B5);
			(B5) = (C5);
			(C5) = tmp;
			tmp = (B6);
			(B6) = (C6);
			(C6) = tmp;
			tmp = (B7);
			(B7) = (C7);
			(C7) = tmp;
			tmp = (B8);
			(B8) = (C8);
			(C8) = tmp;
			tmp = (B9);
			(B9) = (C9);
			(C9) = tmp;
			tmp = (BA);
			(BA) = (CA);
			(CA) = tmp;
			tmp = (BB);
			(BB) = (CB);
			(CB) = tmp;
			tmp = (BC);
			(BC) = (CC);
			(CC) = tmp;
			tmp = (BD);
			(BD) = (CD);
			(CD) = tmp;
			tmp = (BE);
			(BE) = (CE);
			(CE) = tmp;
			tmp = (BF);
			(BF) = (CF);
			(CF) = tmp;

			m_A[0] = A00;
			m_A[1] = A01;
			m_A[2] = A02;
			m_A[3] = A03;
			m_A[4] = A04;
			m_A[5] = A05;
			m_A[6] = A06;
			m_A[7] = A07;
			m_A[8] = A08;
			m_A[9] = A09;
			m_A[10] = A0A;
			m_A[11] = A0B;
			m_B[0] = B0;
			m_B[1] = B1;
			m_B[2] = B2;
			m_B[3] = B3;
			m_B[4] = B4;
			m_B[5] = B5;
			m_B[6] = B6;
			m_B[7] = B7;
			m_B[8] = B8;
			m_B[9] = B9;
			m_B[10] = BA;
			m_B[11] = BB;
			m_B[12] = BC;
			m_B[13] = BD;
			m_B[14] = BE;
			m_B[15] = BF;
			m_C[0] = C0;
			m_C[1] = C1;
			m_C[2] = C2;
			m_C[3] = C3;
			m_C[4] = C4;
			m_C[5] = C5;
			m_C[6] = C6;
			m_C[7] = C7;
			m_C[8] = C8;
			m_C[9] = C9;
			m_C[10] = CA;
			m_C[11] = CB;
			m_C[12] = CC;
			m_C[13] = CD;
			m_C[14] = CE;
			m_C[15] = CF;
		}

		protected override void Finish()
		{
			uint A00, A01, A02, A03, A04, A05, A06, A07, A08, A09, A0A, A0B;
			uint B0, B1, B2, B3, B4, B5, B6, B7, B8, B9, BA, BB, BC, BD, BE, BF;
			uint C0, C1, C2, C3, C4, C5, C6, C7, C8, C9, CA, CB, CC, CD, CE, CF;
			uint M0, M1, M2, M3, M4, M5, M6, M7, M8, M9, MA, MB, MC, MD, ME, MF;
			uint tmp;

			byte[] pad = new byte[BlockSize];
			pad[0] = 0x80;
			m_buffer.Feed(pad, BlockSize - m_buffer.Pos);

			uint[] buffer = new uint[16];
			Converters.ConvertBytesToUInts(m_buffer.GetBytes(), 0, BlockSize, buffer);

			A00 = m_A[0];
			A01 = m_A[1];
			A02 = m_A[2];
			A03 = m_A[3];
			A04 = m_A[4];
			A05 = m_A[5];
			A06 = m_A[6];
			A07 = m_A[7];
			A08 = m_A[8];
			A09 = m_A[9];
			A0A = m_A[10];
			A0B = m_A[11];

			B0 = m_B[0];
			B1 = m_B[1];
			B2 = m_B[2];
			B3 = m_B[3];
			B4 = m_B[4];
			B5 = m_B[5];
			B6 = m_B[6];
			B7 = m_B[7];
			B8 = m_B[8];
			B9 = m_B[9];
			BA = m_B[10];
			BB = m_B[11];
			BC = m_B[12];
			BD = m_B[13];
			BE = m_B[14];
			BF = m_B[15];

			C0 = m_C[0];
			C1 = m_C[1];
			C2 = m_C[2];
			C3 = m_C[3];
			C4 = m_C[4];
			C5 = m_C[5];
			C6 = m_C[6];
			C7 = m_C[7];
			C8 = m_C[8];
			C9 = m_C[9];
			CA = m_C[10];
			CB = m_C[11];
			CC = m_C[12];
			CD = m_C[13];
			CE = m_C[14];
			CF = m_C[15];

			M0 = buffer[0];
			M1 = buffer[1];
			M2 = buffer[2];
			M3 = buffer[3];
			M4 = buffer[4];
			M5 = buffer[5];
			M6 = buffer[6];
			M7 = buffer[7];
			M8 = buffer[8];
			M9 = buffer[9];
			MA = buffer[10];
			MB = buffer[11];
			MC = buffer[12];
			MD = buffer[13];
			ME = buffer[14];
			MF = buffer[15];

			B0 = B0 + M0;
			B1 = B1 + M1;
			B2 = B2 + M2;
			B3 = B3 + M3;
			B4 = B4 + M4;
			B5 = B5 + M5;
			B6 = B6 + M6;
			B7 = B7 + M7;
			B8 = B8 + M8;
			B9 = B9 + M9;
			BA = BA + MA;
			BB = BB + MB;
			BC = BC + MC;
			BD = BD + MD;
			BE = BE + ME;
			BF = BF + MF;

			ulong blocks = m_processed_bytes / (ulong)BlockSize + 1;

			A00 ^= (uint)blocks;
			A01 ^= (uint)(blocks >> 32);

			B0 = (B0 << 17) | (B0 >> 15);
			B1 = (B1 << 17) | (B1 >> 15);
			B2 = (B2 << 17) | (B2 >> 15);
			B3 = (B3 << 17) | (B3 >> 15);
			B4 = (B4 << 17) | (B4 >> 15);
			B5 = (B5 << 17) | (B5 >> 15);
			B6 = (B6 << 17) | (B6 >> 15);
			B7 = (B7 << 17) | (B7 >> 15);
			B8 = (B8 << 17) | (B8 >> 15);
			B9 = (B9 << 17) | (B9 >> 15);
			BA = (BA << 17) | (BA >> 15);
			BB = (BB << 17) | (BB >> 15);
			BC = (BC << 17) | (BC >> 15);
			BD = (BD << 17) | (BD >> 15);
			BE = (BE << 17) | (BE >> 15);
			BF = (BF << 17) | (BF >> 15);

			A00 = ((A00 ^ (((A0B << 15) | (A0B >> 17)) * 5) ^ C8) * 3) ^ BD ^ (B9 & ~B6) ^ M0;
			B0 = ~(((B0 << 1) | (B0 >> 31)) ^ A00);
			A01 = ((A01 ^ (((A00 << 15) | (A00 >> 17)) * 5) ^ C7) * 3) ^ BE ^ (BA & ~B7) ^ M1;
			B1 = ~(((B1 << 1) | (B1 >> 31)) ^ A01);
			A02 = ((A02 ^ (((A01 << 15) | (A01 >> 17)) * 5) ^ C6) * 3) ^ BF ^ (BB & ~B8) ^ M2;
			B2 = ~(((B2 << 1) | (B2 >> 31)) ^ A02);
			A03 = ((A03 ^ (((A02 << 15) | (A02 >> 17)) * 5) ^ C5) * 3) ^ B0 ^ (BC & ~B9) ^ M3;
			B3 = ~(((B3 << 1) | (B3 >> 31)) ^ A03);
			A04 = ((A04 ^ (((A03 << 15) | (A03 >> 17)) * 5) ^ C4) * 3) ^ B1 ^ (BD & ~BA) ^ M4;
			B4 = ~(((B4 << 1) | (B4 >> 31)) ^ A04);
			A05 = ((A05 ^ (((A04 << 15) | (A04 >> 17)) * 5) ^ C3) * 3) ^ B2 ^ (BE & ~BB) ^ M5;
			B5 = ~(((B5 << 1) | (B5 >> 31)) ^ A05);
			A06 = ((A06 ^ (((A05 << 15) | (A05 >> 17)) * 5) ^ C2) * 3) ^ B3 ^ (BF & ~BC) ^ M6;
			B6 = ~(((B6 << 1) | (B6 >> 31)) ^ A06);
			A07 = ((A07 ^ (((A06 << 15) | (A06 >> 17)) * 5) ^ C1) * 3) ^ B4 ^ (B0 & ~BD) ^ M7;
			B7 = ~(((B7 << 1) | (B7 >> 31)) ^ A07);
			A08 = ((A08 ^ (((A07 << 15) | (A07 >> 17)) * 5) ^ C0) * 3) ^ B5 ^ (B1 & ~BE) ^ M8;
			B8 = ~(((B8 << 1) | (B8 >> 31)) ^ A08);
			A09 = ((A09 ^ (((A08 << 15) | (A08 >> 17)) * 5) ^ CF) * 3) ^ B6 ^ (B2 & ~BF) ^ M9;
			B9 = ~(((B9 << 1) | (B9 >> 31)) ^ A09);
			A0A = ((A0A ^ (((A09 << 15) | (A09 >> 17)) * 5) ^ CE) * 3) ^ B7 ^ (B3 & ~B0) ^ MA;
			BA = ~(((BA << 1) | (BA >> 31)) ^ A0A);
			A0B = ((A0B ^ (((A0A << 15) | (A0A >> 17)) * 5) ^ CD) * 3) ^ B8 ^ (B4 & ~B1) ^ MB;
			BB = ~(((BB << 1) | (BB >> 31)) ^ A0B);
			A00 = ((A00 ^ (((A0B << 15) | (A0B >> 17)) * 5) ^ CC) * 3) ^ B9 ^ (B5 & ~B2) ^ MC;
			BC = ~(((BC << 1) | (BC >> 31)) ^ A00);
			A01 = ((A01 ^ (((A00 << 15) | (A00 >> 17)) * 5) ^ CB) * 3) ^ BA ^ (B6 & ~B3) ^ MD;
			BD = ~(((BD << 1) | (BD >> 31)) ^ A01);
			A02 = ((A02 ^ (((A01 << 15) | (A01 >> 17)) * 5) ^ CA) * 3) ^ BB ^ (B7 & ~B4) ^ ME;
			BE = ~(((BE << 1) | (BE >> 31)) ^ A02);
			A03 = ((A03 ^ (((A02 << 15) | (A02 >> 17)) * 5) ^ C9) * 3) ^ BC ^ (B8 & ~B5) ^ MF;
			BF = ~(((BF << 1) | (BF >> 31)) ^ A03);
			A04 = ((A04 ^ (((A03 << 15) | (A03 >> 17)) * 5) ^ C8) * 3) ^ BD ^ (B9 & ~B6) ^ M0;
			B0 = ~(((B0 << 1) | (B0 >> 31)) ^ A04);
			A05 = ((A05 ^ (((A04 << 15) | (A04 >> 17)) * 5) ^ C7) * 3) ^ BE ^ (BA & ~B7) ^ M1;
			B1 = ~(((B1 << 1) | (B1 >> 31)) ^ A05);
			A06 = ((A06 ^ (((A05 << 15) | (A05 >> 17)) * 5) ^ C6) * 3) ^ BF ^ (BB & ~B8) ^ M2;
			B2 = ~(((B2 << 1) | (B2 >> 31)) ^ A06);
			A07 = ((A07 ^ (((A06 << 15) | (A06 >> 17)) * 5) ^ C5) * 3) ^ B0 ^ (BC & ~B9) ^ M3;
			B3 = ~(((B3 << 1) | (B3 >> 31)) ^ A07);
			A08 = ((A08 ^ (((A07 << 15) | (A07 >> 17)) * 5) ^ C4) * 3) ^ B1 ^ (BD & ~BA) ^ M4;
			B4 = ~(((B4 << 1) | (B4 >> 31)) ^ A08);
			A09 = ((A09 ^ (((A08 << 15) | (A08 >> 17)) * 5) ^ C3) * 3) ^ B2 ^ (BE & ~BB) ^ M5;
			B5 = ~(((B5 << 1) | (B5 >> 31)) ^ A09);
			A0A = ((A0A ^ (((A09 << 15) | (A09 >> 17)) * 5) ^ C2) * 3) ^ B3 ^ (BF & ~BC) ^ M6;
			B6 = ~(((B6 << 1) | (B6 >> 31)) ^ A0A);
			A0B = ((A0B ^ (((A0A << 15) | (A0A >> 17)) * 5) ^ C1) * 3) ^ B4 ^ (B0 & ~BD) ^ M7;
			B7 = ~(((B7 << 1) | (B7 >> 31)) ^ A0B);
			A00 = ((A00 ^ (((A0B << 15) | (A0B >> 17)) * 5) ^ C0) * 3) ^ B5 ^ (B1 & ~BE) ^ M8;
			B8 = ~(((B8 << 1) | (B8 >> 31)) ^ A00);
			A01 = ((A01 ^ (((A00 << 15) | (A00 >> 17)) * 5) ^ CF) * 3) ^ B6 ^ (B2 & ~BF) ^ M9;
			B9 = ~(((B9 << 1) | (B9 >> 31)) ^ A01);
			A02 = ((A02 ^ (((A01 << 15) | (A01 >> 17)) * 5) ^ CE) * 3) ^ B7 ^ (B3 & ~B0) ^ MA;
			BA = ~(((BA << 1) | (BA >> 31)) ^ A02);
			A03 = ((A03 ^ (((A02 << 15) | (A02 >> 17)) * 5) ^ CD) * 3) ^ B8 ^ (B4 & ~B1) ^ MB;
			BB = ~(((BB << 1) | (BB >> 31)) ^ A03);
			A04 = ((A04 ^ (((A03 << 15) | (A03 >> 17)) * 5) ^ CC) * 3) ^ B9 ^ (B5 & ~B2) ^ MC;
			BC = ~(((BC << 1) | (BC >> 31)) ^ A04);
			A05 = ((A05 ^ (((A04 << 15) | (A04 >> 17)) * 5) ^ CB) * 3) ^ BA ^ (B6 & ~B3) ^ MD;
			BD = ~(((BD << 1) | (BD >> 31)) ^ A05);
			A06 = ((A06 ^ (((A05 << 15) | (A05 >> 17)) * 5) ^ CA) * 3) ^ BB ^ (B7 & ~B4) ^ ME;
			BE = ~(((BE << 1) | (BE >> 31)) ^ A06);
			A07 = ((A07 ^ (((A06 << 15) | (A06 >> 17)) * 5) ^ C9) * 3) ^ BC ^ (B8 & ~B5) ^ MF;
			BF = ~(((BF << 1) | (BF >> 31)) ^ A07);
			A08 = ((A08 ^ (((A07 << 15) | (A07 >> 17)) * 5) ^ C8) * 3) ^ BD ^ (B9 & ~B6) ^ M0;
			B0 = ~(((B0 << 1) | (B0 >> 31)) ^ A08);
			A09 = ((A09 ^ (((A08 << 15) | (A08 >> 17)) * 5) ^ C7) * 3) ^ BE ^ (BA & ~B7) ^ M1;
			B1 = ~(((B1 << 1) | (B1 >> 31)) ^ A09);
			A0A = ((A0A ^ (((A09 << 15) | (A09 >> 17)) * 5) ^ C6) * 3) ^ BF ^ (BB & ~B8) ^ M2;
			B2 = ~(((B2 << 1) | (B2 >> 31)) ^ A0A);
			A0B = ((A0B ^ (((A0A << 15) | (A0A >> 17)) * 5) ^ C5) * 3) ^ B0 ^ (BC & ~B9) ^ M3;
			B3 = ~(((B3 << 1) | (B3 >> 31)) ^ A0B);
			A00 = ((A00 ^ (((A0B << 15) | (A0B >> 17)) * 5) ^ C4) * 3) ^ B1 ^ (BD & ~BA) ^ M4;
			B4 = ~(((B4 << 1) | (B4 >> 31)) ^ A00);
			A01 = ((A01 ^ (((A00 << 15) | (A00 >> 17)) * 5) ^ C3) * 3) ^ B2 ^ (BE & ~BB) ^ M5;
			B5 = ~(((B5 << 1) | (B5 >> 31)) ^ A01);
			A02 = ((A02 ^ (((A01 << 15) | (A01 >> 17)) * 5) ^ C2) * 3) ^ B3 ^ (BF & ~BC) ^ M6;
			B6 = ~(((B6 << 1) | (B6 >> 31)) ^ A02);
			A03 = ((A03 ^ (((A02 << 15) | (A02 >> 17)) * 5) ^ C1) * 3) ^ B4 ^ (B0 & ~BD) ^ M7;
			B7 = ~(((B7 << 1) | (B7 >> 31)) ^ A03);
			A04 = ((A04 ^ (((A03 << 15) | (A03 >> 17)) * 5) ^ C0) * 3) ^ B5 ^ (B1 & ~BE) ^ M8;
			B8 = ~(((B8 << 1) | (B8 >> 31)) ^ A04);
			A05 = ((A05 ^ (((A04 << 15) | (A04 >> 17)) * 5) ^ CF) * 3) ^ B6 ^ (B2 & ~BF) ^ M9;
			B9 = ~(((B9 << 1) | (B9 >> 31)) ^ A05);
			A06 = ((A06 ^ (((A05 << 15) | (A05 >> 17)) * 5) ^ CE) * 3) ^ B7 ^ (B3 & ~B0) ^ MA;
			BA = ~(((BA << 1) | (BA >> 31)) ^ A06);
			A07 = ((A07 ^ (((A06 << 15) | (A06 >> 17)) * 5) ^ CD) * 3) ^ B8 ^ (B4 & ~B1) ^ MB;
			BB = ~(((BB << 1) | (BB >> 31)) ^ A07);
			A08 = ((A08 ^ (((A07 << 15) | (A07 >> 17)) * 5) ^ CC) * 3) ^ B9 ^ (B5 & ~B2) ^ MC;
			BC = ~(((BC << 1) | (BC >> 31)) ^ A08);
			A09 = ((A09 ^ (((A08 << 15) | (A08 >> 17)) * 5) ^ CB) * 3) ^ BA ^ (B6 & ~B3) ^ MD;
			BD = ~(((BD << 1) | (BD >> 31)) ^ A09);
			A0A = ((A0A ^ (((A09 << 15) | (A09 >> 17)) * 5) ^ CA) * 3) ^ BB ^ (B7 & ~B4) ^ ME;
			BE = ~(((BE << 1) | (BE >> 31)) ^ A0A);
			A0B = ((A0B ^ (((A0A << 15) | (A0A >> 17)) * 5) ^ C9) * 3) ^ BC ^ (B8 & ~B5) ^ MF;
			BF = ~(((BF << 1) | (BF >> 31)) ^ A0B);

			A0B = A0B + C6;
			A0A = A0A + C5;
			A09 = A09 + C4;
			A08 = A08 + C3;
			A07 = A07 + C2;
			A06 = A06 + C1;
			A05 = A05 + C0;
			A04 = A04 + CF;
			A03 = A03 + CE;
			A02 = A02 + CD;
			A01 = A01 + CC;
			A00 = A00 + CB;
			A0B = A0B + CA;
			A0A = A0A + C9;
			A09 = A09 + C8;
			A08 = A08 + C7;
			A07 = A07 + C6;
			A06 = A06 + C5;
			A05 = A05 + C4;
			A04 = A04 + C3;
			A03 = A03 + C2;
			A02 = A02 + C1;
			A01 = A01 + C0;
			A00 = A00 + CF;
			A0B = A0B + CE;
			A0A = A0A + CD;
			A09 = A09 + CC;
			A08 = A08 + CB;
			A07 = A07 + CA;
			A06 = A06 + C9;
			A05 = A05 + C8;
			A04 = A04 + C7;
			A03 = A03 + C6;
			A02 = A02 + C5;
			A01 = A01 + C4;
			A00 = A00 + C3;

			for (int i = 0; i < 3; i++)
			{
				tmp = (B0);
				(B0) = (C0);
				(C0) = tmp;
				tmp = (B1);
				(B1) = (C1);
				(C1) = tmp;
				tmp = (B2);
				(B2) = (C2);
				(C2) = tmp;
				tmp = (B3);
				(B3) = (C3);
				(C3) = tmp;
				tmp = (B4);
				(B4) = (C4);
				(C4) = tmp;
				tmp = (B5);
				(B5) = (C5);
				(C5) = tmp;
				tmp = (B6);
				(B6) = (C6);
				(C6) = tmp;
				tmp = (B7);
				(B7) = (C7);
				(C7) = tmp;
				tmp = (B8);
				(B8) = (C8);
				(C8) = tmp;
				tmp = (B9);
				(B9) = (C9);
				(C9) = tmp;
				tmp = (BA);
				(BA) = (CA);
				(CA) = tmp;
				tmp = (BB);
				(BB) = (CB);
				(CB) = tmp;
				tmp = (BC);
				(BC) = (CC);
				(CC) = tmp;
				tmp = (BD);
				(BD) = (CD);
				(CD) = tmp;
				tmp = (BE);
				(BE) = (CE);
				(CE) = tmp;
				tmp = (BF);
				(BF) = (CF);
				(CF) = tmp;

				A00 ^= (uint)blocks;
				A01 ^= (uint)(blocks >> 32);

				B0 = (B0 << 17) | (B0 >> 15);
				B1 = (B1 << 17) | (B1 >> 15);
				B2 = (B2 << 17) | (B2 >> 15);
				B3 = (B3 << 17) | (B3 >> 15);
				B4 = (B4 << 17) | (B4 >> 15);
				B5 = (B5 << 17) | (B5 >> 15);
				B6 = (B6 << 17) | (B6 >> 15);
				B7 = (B7 << 17) | (B7 >> 15);
				B8 = (B8 << 17) | (B8 >> 15);
				B9 = (B9 << 17) | (B9 >> 15);
				BA = (BA << 17) | (BA >> 15);
				BB = (BB << 17) | (BB >> 15);
				BC = (BC << 17) | (BC >> 15);
				BD = (BD << 17) | (BD >> 15);
				BE = (BE << 17) | (BE >> 15);
				BF = (BF << 17) | (BF >> 15);

				A00 = ((A00 ^ (((A0B << 15) | (A0B >> 17)) * 5) ^ C8) * 3) ^ BD ^ (B9 & ~B6) ^ M0;
				B0 = ~(((B0 << 1) | (B0 >> 31)) ^ A00);
				A01 = ((A01 ^ (((A00 << 15) | (A00 >> 17)) * 5) ^ C7) * 3) ^ BE ^ (BA & ~B7) ^ M1;
				B1 = ~(((B1 << 1) | (B1 >> 31)) ^ A01);
				A02 = ((A02 ^ (((A01 << 15) | (A01 >> 17)) * 5) ^ C6) * 3) ^ BF ^ (BB & ~B8) ^ M2;
				B2 = ~(((B2 << 1) | (B2 >> 31)) ^ A02);
				A03 = ((A03 ^ (((A02 << 15) | (A02 >> 17)) * 5) ^ C5) * 3) ^ B0 ^ (BC & ~B9) ^ M3;
				B3 = ~(((B3 << 1) | (B3 >> 31)) ^ A03);
				A04 = ((A04 ^ (((A03 << 15) | (A03 >> 17)) * 5) ^ C4) * 3) ^ B1 ^ (BD & ~BA) ^ M4;
				B4 = ~(((B4 << 1) | (B4 >> 31)) ^ A04);
				A05 = ((A05 ^ (((A04 << 15) | (A04 >> 17)) * 5) ^ C3) * 3) ^ B2 ^ (BE & ~BB) ^ M5;
				B5 = ~(((B5 << 1) | (B5 >> 31)) ^ A05);
				A06 = ((A06 ^ (((A05 << 15) | (A05 >> 17)) * 5) ^ C2) * 3) ^ B3 ^ (BF & ~BC) ^ M6;
				B6 = ~(((B6 << 1) | (B6 >> 31)) ^ A06);
				A07 = ((A07 ^ (((A06 << 15) | (A06 >> 17)) * 5) ^ C1) * 3) ^ B4 ^ (B0 & ~BD) ^ M7;
				B7 = ~(((B7 << 1) | (B7 >> 31)) ^ A07);
				A08 = ((A08 ^ (((A07 << 15) | (A07 >> 17)) * 5) ^ C0) * 3) ^ B5 ^ (B1 & ~BE) ^ M8;
				B8 = ~(((B8 << 1) | (B8 >> 31)) ^ A08);
				A09 = ((A09 ^ (((A08 << 15) | (A08 >> 17)) * 5) ^ CF) * 3) ^ B6 ^ (B2 & ~BF) ^ M9;
				B9 = ~(((B9 << 1) | (B9 >> 31)) ^ A09);
				A0A = ((A0A ^ (((A09 << 15) | (A09 >> 17)) * 5) ^ CE) * 3) ^ B7 ^ (B3 & ~B0) ^ MA;
				BA = ~(((BA << 1) | (BA >> 31)) ^ A0A);
				A0B = ((A0B ^ (((A0A << 15) | (A0A >> 17)) * 5) ^ CD) * 3) ^ B8 ^ (B4 & ~B1) ^ MB;
				BB = ~(((BB << 1) | (BB >> 31)) ^ A0B);
				A00 = ((A00 ^ (((A0B << 15) | (A0B >> 17)) * 5) ^ CC) * 3) ^ B9 ^ (B5 & ~B2) ^ MC;
				BC = ~(((BC << 1) | (BC >> 31)) ^ A00);
				A01 = ((A01 ^ (((A00 << 15) | (A00 >> 17)) * 5) ^ CB) * 3) ^ BA ^ (B6 & ~B3) ^ MD;
				BD = ~(((BD << 1) | (BD >> 31)) ^ A01);
				A02 = ((A02 ^ (((A01 << 15) | (A01 >> 17)) * 5) ^ CA) * 3) ^ BB ^ (B7 & ~B4) ^ ME;
				BE = ~(((BE << 1) | (BE >> 31)) ^ A02);
				A03 = ((A03 ^ (((A02 << 15) | (A02 >> 17)) * 5) ^ C9) * 3) ^ BC ^ (B8 & ~B5) ^ MF;
				BF = ~(((BF << 1) | (BF >> 31)) ^ A03);
				A04 = ((A04 ^ (((A03 << 15) | (A03 >> 17)) * 5) ^ C8) * 3) ^ BD ^ (B9 & ~B6) ^ M0;
				B0 = ~(((B0 << 1) | (B0 >> 31)) ^ A04);
				A05 = ((A05 ^ (((A04 << 15) | (A04 >> 17)) * 5) ^ C7) * 3) ^ BE ^ (BA & ~B7) ^ M1;
				B1 = ~(((B1 << 1) | (B1 >> 31)) ^ A05);
				A06 = ((A06 ^ (((A05 << 15) | (A05 >> 17)) * 5) ^ C6) * 3) ^ BF ^ (BB & ~B8) ^ M2;
				B2 = ~(((B2 << 1) | (B2 >> 31)) ^ A06);
				A07 = ((A07 ^ (((A06 << 15) | (A06 >> 17)) * 5) ^ C5) * 3) ^ B0 ^ (BC & ~B9) ^ M3;
				B3 = ~(((B3 << 1) | (B3 >> 31)) ^ A07);
				A08 = ((A08 ^ (((A07 << 15) | (A07 >> 17)) * 5) ^ C4) * 3) ^ B1 ^ (BD & ~BA) ^ M4;
				B4 = ~(((B4 << 1) | (B4 >> 31)) ^ A08);
				A09 = ((A09 ^ (((A08 << 15) | (A08 >> 17)) * 5) ^ C3) * 3) ^ B2 ^ (BE & ~BB) ^ M5;
				B5 = ~(((B5 << 1) | (B5 >> 31)) ^ A09);
				A0A = ((A0A ^ (((A09 << 15) | (A09 >> 17)) * 5) ^ C2) * 3) ^ B3 ^ (BF & ~BC) ^ M6;
				B6 = ~(((B6 << 1) | (B6 >> 31)) ^ A0A);
				A0B = ((A0B ^ (((A0A << 15) | (A0A >> 17)) * 5) ^ C1) * 3) ^ B4 ^ (B0 & ~BD) ^ M7;
				B7 = ~(((B7 << 1) | (B7 >> 31)) ^ A0B);
				A00 = ((A00 ^ (((A0B << 15) | (A0B >> 17)) * 5) ^ C0) * 3) ^ B5 ^ (B1 & ~BE) ^ M8;
				B8 = ~(((B8 << 1) | (B8 >> 31)) ^ A00);
				A01 = ((A01 ^ (((A00 << 15) | (A00 >> 17)) * 5) ^ CF) * 3) ^ B6 ^ (B2 & ~BF) ^ M9;
				B9 = ~(((B9 << 1) | (B9 >> 31)) ^ A01);
				A02 = ((A02 ^ (((A01 << 15) | (A01 >> 17)) * 5) ^ CE) * 3) ^ B7 ^ (B3 & ~B0) ^ MA;
				BA = ~(((BA << 1) | (BA >> 31)) ^ A02);
				A03 = ((A03 ^ (((A02 << 15) | (A02 >> 17)) * 5) ^ CD) * 3) ^ B8 ^ (B4 & ~B1) ^ MB;
				BB = ~(((BB << 1) | (BB >> 31)) ^ A03);
				A04 = ((A04 ^ (((A03 << 15) | (A03 >> 17)) * 5) ^ CC) * 3) ^ B9 ^ (B5 & ~B2) ^ MC;
				BC = ~(((BC << 1) | (BC >> 31)) ^ A04);
				A05 = ((A05 ^ (((A04 << 15) | (A04 >> 17)) * 5) ^ CB) * 3) ^ BA ^ (B6 & ~B3) ^ MD;
				BD = ~(((BD << 1) | (BD >> 31)) ^ A05);
				A06 = ((A06 ^ (((A05 << 15) | (A05 >> 17)) * 5) ^ CA) * 3) ^ BB ^ (B7 & ~B4) ^ ME;
				BE = ~(((BE << 1) | (BE >> 31)) ^ A06);
				A07 = ((A07 ^ (((A06 << 15) | (A06 >> 17)) * 5) ^ C9) * 3) ^ BC ^ (B8 & ~B5) ^ MF;
				BF = ~(((BF << 1) | (BF >> 31)) ^ A07);
				A08 = ((A08 ^ (((A07 << 15) | (A07 >> 17)) * 5) ^ C8) * 3) ^ BD ^ (B9 & ~B6) ^ M0;
				B0 = ~(((B0 << 1) | (B0 >> 31)) ^ A08);
				A09 = ((A09 ^ (((A08 << 15) | (A08 >> 17)) * 5) ^ C7) * 3) ^ BE ^ (BA & ~B7) ^ M1;
				B1 = ~(((B1 << 1) | (B1 >> 31)) ^ A09);
				A0A = ((A0A ^ (((A09 << 15) | (A09 >> 17)) * 5) ^ C6) * 3) ^ BF ^ (BB & ~B8) ^ M2;
				B2 = ~(((B2 << 1) | (B2 >> 31)) ^ A0A);
				A0B = ((A0B ^ (((A0A << 15) | (A0A >> 17)) * 5) ^ C5) * 3) ^ B0 ^ (BC & ~B9) ^ M3;
				B3 = ~(((B3 << 1) | (B3 >> 31)) ^ A0B);
				A00 = ((A00 ^ (((A0B << 15) | (A0B >> 17)) * 5) ^ C4) * 3) ^ B1 ^ (BD & ~BA) ^ M4;
				B4 = ~(((B4 << 1) | (B4 >> 31)) ^ A00);
				A01 = ((A01 ^ (((A00 << 15) | (A00 >> 17)) * 5) ^ C3) * 3) ^ B2 ^ (BE & ~BB) ^ M5;
				B5 = ~(((B5 << 1) | (B5 >> 31)) ^ A01);
				A02 = ((A02 ^ (((A01 << 15) | (A01 >> 17)) * 5) ^ C2) * 3) ^ B3 ^ (BF & ~BC) ^ M6;
				B6 = ~(((B6 << 1) | (B6 >> 31)) ^ A02);
				A03 = ((A03 ^ (((A02 << 15) | (A02 >> 17)) * 5) ^ C1) * 3) ^ B4 ^ (B0 & ~BD) ^ M7;
				B7 = ~(((B7 << 1) | (B7 >> 31)) ^ A03);
				A04 = ((A04 ^ (((A03 << 15) | (A03 >> 17)) * 5) ^ C0) * 3) ^ B5 ^ (B1 & ~BE) ^ M8;
				B8 = ~(((B8 << 1) | (B8 >> 31)) ^ A04);
				A05 = ((A05 ^ (((A04 << 15) | (A04 >> 17)) * 5) ^ CF) * 3) ^ B6 ^ (B2 & ~BF) ^ M9;
				B9 = ~(((B9 << 1) | (B9 >> 31)) ^ A05);
				A06 = ((A06 ^ (((A05 << 15) | (A05 >> 17)) * 5) ^ CE) * 3) ^ B7 ^ (B3 & ~B0) ^ MA;
				BA = ~(((BA << 1) | (BA >> 31)) ^ A06);
				A07 = ((A07 ^ (((A06 << 15) | (A06 >> 17)) * 5) ^ CD) * 3) ^ B8 ^ (B4 & ~B1) ^ MB;
				BB = ~(((BB << 1) | (BB >> 31)) ^ A07);
				A08 = ((A08 ^ (((A07 << 15) | (A07 >> 17)) * 5) ^ CC) * 3) ^ B9 ^ (B5 & ~B2) ^ MC;
				BC = ~(((BC << 1) | (BC >> 31)) ^ A08);
				A09 = ((A09 ^ (((A08 << 15) | (A08 >> 17)) * 5) ^ CB) * 3) ^ BA ^ (B6 & ~B3) ^ MD;
				BD = ~(((BD << 1) | (BD >> 31)) ^ A09);
				A0A = ((A0A ^ (((A09 << 15) | (A09 >> 17)) * 5) ^ CA) * 3) ^ BB ^ (B7 & ~B4) ^ ME;
				BE = ~(((BE << 1) | (BE >> 31)) ^ A0A);
				A0B = ((A0B ^ (((A0A << 15) | (A0A >> 17)) * 5) ^ C9) * 3) ^ BC ^ (B8 & ~B5) ^ MF;
				BF = ~(((BF << 1) | (BF >> 31)) ^ A0B);

				A0B = A0B + C6;
				A0A = A0A + C5;
				A09 = A09 + C4;
				A08 = A08 + C3;
				A07 = A07 + C2;
				A06 = A06 + C1;
				A05 = A05 + C0;
				A04 = A04 + CF;
				A03 = A03 + CE;
				A02 = A02 + CD;
				A01 = A01 + CC;
				A00 = A00 + CB;
				A0B = A0B + CA;
				A0A = A0A + C9;
				A09 = A09 + C8;
				A08 = A08 + C7;
				A07 = A07 + C6;
				A06 = A06 + C5;
				A05 = A05 + C4;
				A04 = A04 + C3;
				A03 = A03 + C2;
				A02 = A02 + C1;
				A01 = A01 + C0;
				A00 = A00 + CF;
				A0B = A0B + CE;
				A0A = A0A + CD;
				A09 = A09 + CC;
				A08 = A08 + CB;
				A07 = A07 + CA;
				A06 = A06 + C9;
				A05 = A05 + C8;
				A04 = A04 + C7;
				A03 = A03 + C6;
				A02 = A02 + C5;
				A01 = A01 + C4;
				A00 = A00 + C3;
			}

			m_A[0] = A00;
			m_A[1] = A01;
			m_A[2] = A02;
			m_A[3] = A03;
			m_A[4] = A04;
			m_A[5] = A05;
			m_A[6] = A06;
			m_A[7] = A07;
			m_A[8] = A08;
			m_A[9] = A09;
			m_A[10] = A0A;
			m_A[11] = A0B;
			m_B[0] = B0;
			m_B[1] = B1;
			m_B[2] = B2;
			m_B[3] = B3;
			m_B[4] = B4;
			m_B[5] = B5;
			m_B[6] = B6;
			m_B[7] = B7;
			m_B[8] = B8;
			m_B[9] = B9;
			m_B[10] = BA;
			m_B[11] = BB;
			m_B[12] = BC;
			m_B[13] = BD;
			m_B[14] = BE;
			m_B[15] = BF;
			m_C[0] = C0;
			m_C[1] = C1;
			m_C[2] = C2;
			m_C[3] = C3;
			m_C[4] = C4;
			m_C[5] = C5;
			m_C[6] = C6;
			m_C[7] = C7;
			m_C[8] = C8;
			m_C[9] = C9;
			m_C[10] = CA;
			m_C[11] = CB;
			m_C[12] = CC;
			m_C[13] = CD;
			m_C[14] = CE;
			m_C[15] = CF;
		}

		protected override byte[] GetResult()
		{
			return Converters.ConvertUIntsToBytes(m_B).SubArray(64 - HashSize, HashSize);
		}

		public override void Initialize()
		{
			switch (HashSize)
			{
				case 28:

					Array.Copy(s_A_init_224, m_A, 12);
					Array.Copy(s_B_init_224, m_B, 16);
					Array.Copy(s_C_init_224, m_C, 16);
					break;

				case 32:

					Array.Copy(s_A_init_256, m_A, 12);
					Array.Copy(s_B_init_256, m_B, 16);
					Array.Copy(s_C_init_256, m_C, 16);
					break;

				case 48:

					Array.Copy(s_A_init_384, m_A, 12);
					Array.Copy(s_B_init_384, m_B, 16);
					Array.Copy(s_C_init_384, m_C, 16);
					break;

				case 64:

					Array.Copy(s_A_init_512, m_A, 12);
					Array.Copy(s_B_init_512, m_B, 16);
					Array.Copy(s_C_init_512, m_C, 16);
					break;
			}

			base.Initialize();
		}
	};
}