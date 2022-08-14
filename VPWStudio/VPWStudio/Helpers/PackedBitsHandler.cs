using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace VPWStudio
{
	/// <summary>
	/// This class houses routines for dealing with packed bits.
	/// Specifically, the wrestler Parameters and Moves found in WrestleMania 2000 and later.
	/// </summary>
	public class PackedBitsHandler
	{
		// Addresses in these variable names are for VPW2
		#region Bit Packing Variables
		public static UInt16 bssMain_800571F0;
		public static UInt16 bssMain_800571F2;
		#endregion

		#region Bit Unpacking Variables
		public static UInt16 bssMain_800571F4;
		public static UInt16 bssMain_800571F6;
		#endregion

		// VPW2 relevant locations of interest:
		// tbl_8003C8E0 (pro-wrestler), tbl_8003CEDC (combo), tbl_8003D4EC (shootfighting) - move slot definitions
		// tbl_8003D930 - number of bits required for each move category (add 5 to value for real number of bits)

		// $a0=address, $a2=shiftVal1, $a3=shiftVal2, 0x10($sp)=numBits -> 0x18($sp), 0x14($sp)=mode -> 0x1C($sp)
		/// <summary>
		/// Bit packing routine.
		/// </summary>
		/// VPW2 locations: runtime 80004D60, Z64 ROM offset 0x005960
		/// <param name="numBits">Number of bits to pack.</param>
		/// <param name="mode">0 for setup, 1 for actual bit packing.</param>
		/// <returns>Packed value, or 0 in certain circumstances (mode==0; numBits <=0).</returns>
		public static int PackBits(/* uint address, uint shiftVal1, uint shiftVal2, */ int numBits /* $a1 */, int mode /* $a2 */)
		{
			if (mode == 0)
			{
				// perform setup
				bssMain_800571F0 = 0;
				bssMain_800571F2 = 0;
				return 0;
			}

			// can't pack 0 or less bits
			if (numBits <= 0) { return 0; }

			// actual bit packing
			return 0;
		}

		/// <summary>
		/// Bit unpacking routine.
		/// </summary>
		/// VPW2 locations: runtime 80004F64, Z64 ROM offset 0x005B64
		/// <param name="numBits">Number of bits to unpack.</param>
		/// <param name="mode">0 for setup, 1 for actual bit unpacking.</param>
		/// <returns>Unpacked value, or 0 in certain circumstances (mode==0; numBits <=0).</returns>
		public static int UnpackBits(/* uint address, */ int numBits /* $a1 */, int mode /* $a2 */)
		{
			if (mode == 0)
			{
				// perform setup
				bssMain_800571F4 = 0;
				bssMain_800571F6 = 0;
				return 0;
			}

			// can't unpack 0 or less bits
			if (numBits <= 0) { return 0; }

			// actual bit unpacking
			int reg_s0 = 8;
			int reg_s2 = 0;
			int reg_s3 = 0;
			int reg_t0 = 0;
			int reg_t1 = 0;
			int reg_t2 = 0;
			int reg_t3 = 0;
			int reg_t4 = 0;
			int reg_t5 = 0;
			int reg_t6 = 0;
			int reg_t7 = 1;
			int reg_t8 = 0; /* address */
			int reg_t9 = 0;
			int reg_v0 = reg_t4;
			int reg_v1 = 0;
			int reg_a0 = 0;
			int reg_a3 = 0;

#if false
			begin loop
			.L80004FB8:
			/* 005BB8 80004FB8 3C028005 */  lui   $v0, %hi(bssMain_800571F6) # $v0, 0x8005
			/* 005BBC 80004FBC 944271F6 */  lhu   $v0, %lo(bssMain_800571F6)($v0)
			/* 005BC0 80004FC0 02025023 */  subu  $t2, $s0, $v0 # reg_t2 = reg_s0 - reg_v0
			/* 005BC4 80004FC4 00021400 */  sll   $v0, $v0, 0x10 # reg_v0 <<= 0x10
			/* 005BC8 80004FC8 00021403 */  sra   $v0, $v0, 0x10 # reg_v0 >>= 0x10
			/* 005BCC 80004FCC 00451021 */  addu  $v0, $v0, $a1 # reg_v0 += reg_a1

			/* 005BD0 80004FD0 28420009 */  slti  $v0, $v0, 9 # if reg_v0 < 9
			/* 005BD4 80004FD4 10400035 */  beqz  $v0, .L800050AC
			/* 005BD8 80004FD8 01405821 */   addu  $t3, $t2, $zero # reg_t3 = reg_t2
#endif

			lbl_80004FB8:
			reg_v0 = bssMain_800571F6;
			reg_t2 = reg_s0 - reg_v0;
			reg_v0 <<= 0x10;
			reg_v0 >>= 0x10;
			reg_v0 += numBits;
			reg_t3 = reg_t2; // branch delay slot

			// slti  $v0, $v0, 9 # if reg_v0 < 9
			// beqz  $v0, .L800050AC
			/*
			if (reg_v0 < 9 == false)
			{
				goto lbl_800050AC;
			}
			*/

#if false
			/* 005BDC 80004FDC 00051680 */  sll   $v0, $a1, 0x1a # reg_v0 = reg_a1 << 0x1A
			/* 005BE0 80004FE0 04410004 */  bgez  $v0, .L80004FF4 # if reg_v0 >= 0
			/* 005BE4 80004FE4 00000000 */   nop
#endif
			reg_v0 = numBits << 0x1A;

#if false
			only if reg_v0 < 0
			/* 005BE8 80004FE8 00AD9004 */  sllv  $s2, $t5, $a1 # reg_s2 = reg_t5 << reg_a1
			/* 005BEC 80004FEC 10000007 */  b .L8000500C
			/* 005BF0 80004FF0 00009821 */   addu  $s3, $zero, $zero # reg_s3 = 0
			end reg_v0 < 0
#endif
			if (reg_v0 < 0)
			{
				reg_s2 = reg_t5 << numBits;
				reg_s3 = 0; // branch delay slot
				goto lbl_8000500C;
			}

#if false
			.L80004FF4:
			/* 005BF4 80004FF4 10400004 */  beqz  $v0, .L80005008 # if reg_v0 == 0
			/* 005BF8 80004FF8 00AC9004 */   sllv  $s2, $t4, $a1 # reg_s2 = reg_t4 << reg_a1

			/* 005BFC 80004FFC 00051023 */  negu  $v0, $a1 # reg_v0 = ~reg_a1
			/* 005C00 80005000 004D1006 */  srlv  $v0, $t5, $v0 # reg_v0 = reg_t5 << reg_v0
			/* 005C04 80005004 02429025 */  or    $s2, $s2, $v0 # reg_s2 |= reg_v0
#endif

			reg_s2 = reg_t4 << numBits; // branch delay slot
			if (reg_v0 != 0)
			{
				reg_v0 = ~numBits;
				reg_v0 = reg_t5 << reg_v0;
				reg_s2 |= reg_v0;
			}

#if false
			.L80005008:
			/* 005C08 80005008 00AD9804 */  sllv  $s3, $t5, $a1 # reg_s3 = reg_t5 << reg_a1
#endif
			reg_s3 = reg_t5 << numBits;

#if false
			.L8000500C:
			/* 005C0C 8000500C 02406021 */  addu  $t4, $s2, $zero # reg_t4 = reg_s2
			/* 005C10 80005010 02606821 */  addu  $t5, $s3, $zero # reg_t5 = reg_s3
			/* 005C14 80005014 3C028005 */  lui   $v0, %hi(bssMain_800571F4) # $v0, 0x8005
			/* 005C18 80005018 844271F4 */  lh    $v0, %lo(bssMain_800571F4)($v0)
			/* 005C1C 8000501C 00003021 */  addu  $a2, $zero, $zero # reg_a2 = 0
			/* 005C20 80005020 00003821 */  addu  $a3, $zero, $zero # reg_a3 = 0
			/* 005C24 80005024 00002021 */  addu  $a0, $zero, $zero # reg_a0 = 0
			/* 005C28 80005028 03021021 */  addu  $v0, $t8, $v0 # reg_v0 += reg_t8
			/* 005C2C 8000502C 90430000 */  lbu   $v1, ($v0)
#endif

			lbl_8000500C:
			reg_t4 = reg_s2;
			reg_t5 = reg_s3;
			reg_v0 = bssMain_800571F4;
			mode = 0; /* a2 */
			reg_a3 = 0;
			reg_a0 = 0;
			reg_v0 += reg_t8;
			// load byte from address v0 into v1

#if false
			/* 005C30 80005030 000A1400 */  sll   $v0, $t2, 0x10 # reg_v0 = reg_t2 << 0x10
			/* 005C34 80005034 00021403 */  sra   $v0, $v0, 0x10 # reg_v0 >>= 0x10
			/* 005C38 80005038 00451023 */  subu  $v0, $v0, $a1 # reg_v0 -= reg_a1
			/* 005C3C 8000503C 00431807 */  srav  $v1, $v1, $v0
			/* 005C40 80005040 00604821 */  addu  $t1, $v1, $zero # reg_t1 = reg_v1

			/* 005C44 80005044 0325102A */  slt   $v0, $t9, $a1 # reg_v0 = reg_t9 < reg_a1
			/* 005C48 80005048 1040000D */  beqz  $v0, .L80005080
			/* 005C4C 8000504C 000347C3 */   sra   $t0, $v1, 0x1f # reg_t0 = reg_v1 >> 0x1F
#endif

			reg_v0 = reg_t2 << 0x10;
			reg_v0 >>= 0x10;
			reg_v0 -= numBits;
			reg_v1 = reg_v1 >> reg_v0;
			reg_t1 = reg_v1;
			reg_t0 = reg_v1 >> 0x1F; // branch delay slot

#if false
			.L80005050:
			/* 005C50 80005050 00063040 */  sll   $a2, $a2, 1 # reg_a2 <<= 1
			/* 005C54 80005054 000717C2 */  srl   $v0, $a3, 0x1f
			/* 005C58 80005058 00C23025 */  or    $a2, $a2, $v0 # reg_a2 |= reg_v0
			/* 005C5C 8000505C 00073840 */  sll   $a3, $a3, 1 # reg_a3 <<= 1
			/* 005C60 80005060 00CE3025 */  or    $a2, $a2, $t6 # reg_a2 |= reg_t6
			/* 005C64 80005064 24820001 */  addiu $v0, $a0, 1 # reg_v0 = reg_a0+1
			/* 005C68 80005068 00402021 */  addu  $a0, $v0, $zero # reg_a0 = reg_v0
			/* 005C6C 8000506C 00021400 */  sll   $v0, $v0, 0x10 # reg_v0 <<= 0x10
			/* 005C70 80005070 00021403 */  sra   $v0, $v0, 0x10 # reg_v0 >>= 0x10
			/* 005C74 80005074 0045102A */  slt   $v0, $v0, $a1
			/* 005C78 80005078 1440FFF5 */  bnez  $v0, .L80005050
			/* 005C7C 8000507C 00EF3825 */   or    $a3, $a3, $t7 # reg_a3 |= reg_t7
#endif

			lbl_80005050:
			mode <<= 1; /* reg_a2 */
			reg_v0 = reg_a3 >> 0x1F;
			mode |= reg_v0;
			reg_a3 <<= 1;
			mode |= reg_t6;
			reg_v0 = reg_a0 + 1;
			reg_a0 = reg_v0;
			reg_v0 <<= 0x10;
			reg_v0 >>= 0x10;
			reg_a3 |= reg_t7; // branch delay slot

			// slt $v0 $a1
			// bnez back up

#if false
			.L80005080:
			/* 005C80 80005080 3C048005 */  lui   $a0, %hi(bssMain_800571F6) # $a0, 0x8005
			/* 005C84 80005084 948471F6 */  lhu   $a0, %lo(bssMain_800571F6)($a0)
			/* 005C88 80005088 01061024 */  and   $v0, $t0, $a2 # reg_v0 = reg_t0 & reg_a2
			/* 005C8C 8000508C 01271824 */  and   $v1, $t1, $a3 # reg_v1 = reg_t1 & reg_a3
			/* 005C90 80005090 01826025 */  or    $t4, $t4, $v0 # reg_t4 |= reg_v0
			/* 005C94 80005094 01A36825 */  or    $t5, $t5, $v1 # reg_t5 |= reg_v1
			/* 005C98 80005098 00852021 */  addu  $a0, $a0, $a1 # reg_a0 += reg_a1
			/* 005C9C 8000509C 3C018005 */  lui   $at, %hi(bssMain_800571F6) # $at, 0x8005
			/* 005CA0 800050A0 A42471F6 */  sh    $a0, %lo(bssMain_800571F6)($at)
			/* 005CA4 800050A4 0800145E */  j .L80005178
			/* 005CA8 800050A8 00002821 */   addu  $a1, $zero, $zero
#endif

			lbl_80005080:
			reg_a0 = bssMain_800571F6;
			reg_v0 = reg_t0 & mode;
			reg_v1 = reg_t1 & reg_a3;
			reg_t4 |= reg_v0;
			reg_t5 |= reg_v1;
			reg_a0 += numBits;
			bssMain_800571F6 = (ushort)reg_a0;
			numBits = 0; // branch delay slot
			/*goto lbl_80005178;*/

#if false
			.L800050AC:
			/* 005CAC 800050AC 000A1400 */  sll   $v0, $t2, 0x10 # reg_v0 = reg_t2 << 0x10
			/* 005CB0 800050B0 00025403 */  sra   $t2, $v0, 0x10 # reg_t2 = reg_v0 >> 0x10
			/* 005CB4 800050B4 3C028005 */  lui   $v0, %hi(bssMain_800571F4) # $v0, 0x8005
			/* 005CB8 800050B8 844271F4 */  lh    $v0, %lo(bssMain_800571F4)($v0)
			/* 005CBC 800050BC 000A1E80 */  sll   $v1, $t2, 0x1a # reg_v1 = reg_t2 << 0x1A
			/* 005CC0 800050C0 04610004 */  bgez  $v1, .L800050D4
			/* 005CC4 800050C4 00000000 */   nop
#endif

			lbl_800050AC:
			reg_v0 = reg_t2 << 0x10;
			reg_t2 = reg_v0 >> 0x10;
			reg_v0 = bssMain_800571F4;
			reg_v1 = reg_t2 << 0x1A;

#if false
			/* 005CC8 800050C8 014D9004 */  sllv  $s2, $t5, $t2 # reg_s2 = reg_t5 << reg_t2
			/* 005CCC 800050CC 10000007 */  b .L800050EC
			/* 005CD0 800050D0 00009821 */   addu  $s3, $zero, $zero # reg_s3 = 0
#endif
			if (reg_v1 < 0)
			{
				reg_s2 = reg_t5 << reg_t2;
				reg_s3 = 0;
				goto lbl_800050EC;
			}

#if false
			.L800050D4:
			/* 005CD4 800050D4 10600004 */  beqz  $v1, .L800050E8
			/* 005CD8 800050D8 014C9004 */   sllv  $s2, $t4, $t2 # reg_s2 = reg_t4 << reg_t2
#endif
			reg_s2 = reg_t4 << reg_t2; // branch delay slot

#if false
			/* 005CDC 800050DC 000A1823 */  negu  $v1, $t2 # reg_v1 = ~reg_t2
			/* 005CE0 800050E0 006D1806 */  srlv  $v1, $t5, $v1 # reg_v1 = reg_t5 << reg_v1
			/* 005CE4 800050E4 02439025 */  or    $s2, $s2, $v1 # reg_s2 |= reg_v1
#endif
			if (reg_v1 != 0)
			{
				reg_v1 = ~reg_t2;
				reg_v1 = reg_t5 << reg_v1;
				reg_s2 |= reg_v1;
			}

#if false
			.L800050E8:
			/* 005CE8 800050E8 014D9804 */  sllv  $s3, $t5, $t2 # reg_s3 = reg_t5 << reg_t2
#endif

			lbl_800050E8:
			reg_s3 = reg_t5 << reg_t2;

#if false
			.L800050EC:
			/* 005CEC 800050EC 02406021 */  addu  $t4, $s2, $zero # reg_t4 = reg_s2
			/* 005CF0 800050F0 02606821 */  addu  $t5, $s3, $zero # reg_t5 = reg_s3
			/* 005CF4 800050F4 00003021 */  addu  $a2, $zero, $zero # reg_a2 = 0
			/* 005CF8 800050F8 00003821 */  addu  $a3, $zero, $zero # reg_a3 = 0
			/* 005CFC 800050FC 03021021 */  addu  $v0, $t8, $v0 # reg_v0 += reg_t8
			/* 005D00 80005100 90490000 */  lbu   $t1, ($v0)
#endif

			lbl_800050EC:
			reg_t4 = reg_s2;
			reg_t5 = reg_s3;
			mode = 0;
			reg_a3 = 0;
			reg_v0 += reg_t8;
			// load byte from $v0 into $t1

#if false
			/* 005D04 80005104 00002021 */  addu  $a0, $zero, $zero # reg_a0 = 0
			/* 005D08 80005108 032A102A */  slt   $v0, $t9, $t2
			/* 005D0C 8000510C 1040000E */  beqz  $v0, .L80005148
			/* 005D10 80005110 00004021 */   addu  $t0, $zero, $zero # reg_t0 = 0
#endif

			#region UnpackBits assembly
#if false
			"reg_a1" = numBits

			/* 005D14 80005114 01401821 */  addu  $v1, $t2, $zero # reg_v1 = reg_t2
			
			.L80005118:
			/* 005D18 80005118 00063040 */  sll   $a2, $a2, 1 # reg_a2 <<= 1
			/* 005D1C 8000511C 000717C2 */  srl   $v0, $a3, 0x1f # reg_v0 = reg_a3 >> 0x1F
			/* 005D20 80005120 00C23025 */  or    $a2, $a2, $v0 # reg_a2 |= reg_v0
			/* 005D24 80005124 00073840 */  sll   $a3, $a3, 1 # reg_a3 <<= 1
			/* 005D28 80005128 00CE3025 */  or    $a2, $a2, $t6 # reg_a2 |= reg_t6
			/* 005D2C 8000512C 24820001 */  addiu $v0, $a0, 1 # reg_v0 = reg_a0+1
			/* 005D30 80005130 00402021 */  addu  $a0, $v0, $zero # reg_a0 = reg_v0
			/* 005D34 80005134 00021400 */  sll   $v0, $v0, 0x10
			/* 005D38 80005138 00021403 */  sra   $v0, $v0, 0x10
			/* 005D3C 8000513C 0043102A */  slt   $v0, $v0, $v1
			/* 005D40 80005140 1440FFF5 */  bnez  $v0, .L80005118
			/* 005D44 80005144 00EF3825 */   or    $a3, $a3, $t7 # reg_a3 |= reg_t7
			
			.L80005148:
			/* 005D48 80005148 01061024 */  and   $v0, $t0, $a2 # reg_v0 = reg_t0 & reg_a2
			/* 005D4C 8000514C 01271824 */  and   $v1, $t1, $a3 # reg_v1 = reg_t1 & reg_a3
			/* 005D50 80005150 01826025 */  or    $t4, $t4, $v0 # reg_t4 |= reg_v0
			/* 005D54 80005154 01A36825 */  or    $t5, $t5, $v1 # reg_t5 |= reg_v1
			/* 005D58 80005158 000B1400 */  sll   $v0, $t3, 0x10 # reg_v0 = reg_t3 << 0x10
			/* 005D5C 8000515C 3C038005 */  lui   $v1, %hi(bssMain_800571F6) # $v1, 0x8005
			/* 005D60 80005160 946371F6 */  lhu   $v1, %lo(bssMain_800571F6)($v1)
			/* 005D64 80005164 00021403 */  sra   $v0, $v0, 0x10 # reg_v0 >>= 0x10
			/* 005D68 80005168 00A22823 */  subu  $a1, $a1, $v0 # reg_a1 -= reg_v0
			/* 005D6C 8000516C 006B1821 */  addu  $v1, $v1, $t3 # reg_v1 += reg_t3
			/* 005D70 80005170 3C018005 */  lui   $at, %hi(bssMain_800571F6) # $at, 0x8005
			/* 005D74 80005174 A42371F6 */  sh    $v1, %lo(bssMain_800571F6)($at)
			
			.L80005178:
			/* 005D78 80005178 3C028005 */  lui   $v0, %hi(bssMain_800571F6) # $v0, 0x8005
			/* 005D7C 8000517C 844271F6 */  lh    $v0, %lo(bssMain_800571F6)($v0)
			/* 005D80 80005180 00402021 */  addu  $a0, $v0, $zero # reg_a0 = reg_v0
			/* 005D84 80005184 28420008 */  slti  $v0, $v0, 8
			/* 005D88 80005188 14400008 */  bnez  $v0, .L800051AC
			/* 005D8C 8000518C 2482FFF8 */   addiu $v0, $a0, -8 # reg_v0 = reg_a0 - 8
			
			/* 005D90 80005190 3C038005 */  lui   $v1, %hi(bssMain_800571F4) # $v1, 0x8005
			/* 005D94 80005194 946371F4 */  lhu   $v1, %lo(bssMain_800571F4)($v1)
			/* 005D98 80005198 3C018005 */  lui   $at, %hi(bssMain_800571F6) # $at, 0x8005
			/* 005D9C 8000519C A42271F6 */  sh    $v0, %lo(bssMain_800571F6)($at)
			/* 005DA0 800051A0 24630001 */  addiu $v1, $v1, 1 # reg_v1++
			/* 005DA4 800051A4 3C018005 */  lui   $at, %hi(bssMain_800571F4) # $at, 0x8005
			/* 005DA8 800051A8 A42371F4 */  sh    $v1, %lo(bssMain_800571F4)($at)
			
			.L800051AC:
			/* 005DAC 800051AC 1CA0FF82 */  bgtz  $a1, .L80004FB8
			/* 005DB0 800051B0 01801021 */   addu  $v0, $t4, $zero # reg_v0 = reg_t4
			loop ends

			.L800051B4:
			/* 005DB4 800051B4 01A01821 */  addu  $v1, $t5, $zero # reg_v1 = reg_t5
#endif
			#endregion

			return 0;
		}
	}
}
