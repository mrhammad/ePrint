using System;
using System.Text;

namespace HtmlStripTags
{
	public class HtmlHelper
	{
		private readonly static string[][] htmlNamedEntities;

		static HtmlHelper()
		{
			string[][] strArrays = new string[251][];
			string[] strArrays1 = new string[] { "&quot;", "\"" };
			strArrays[0] = strArrays1;
			strArrays[1] = new string[] { "&lt;", "<" };
			strArrays[2] = new string[] { "&gt;", ">" };
			strArrays[3] = new string[] { "&nbsp;", " " };
			strArrays[4] = new string[] { "&iexcl;", "¡" };
			strArrays[5] = new string[] { "&cent;", "¢" };
			strArrays[6] = new string[] { "&pound;", "£" };
			strArrays[7] = new string[] { "&curren;", "¤" };
			strArrays[8] = new string[] { "&yen;", "¥" };
			strArrays[9] = new string[] { "&brvbar;", "¦" };
			strArrays[10] = new string[] { "&sect;", "§" };
			strArrays[11] = new string[] { "&uml;", "¨" };
			strArrays[12] = new string[] { "&copy;", "©" };
			strArrays[13] = new string[] { "&ordf;", "ª" };
			strArrays[14] = new string[] { "&laquo;", "«" };
			strArrays[15] = new string[] { "&not;", "¬" };
			strArrays[16] = new string[] { "&shy;", "­" };
			strArrays[17] = new string[] { "&reg;", "®" };
			strArrays[18] = new string[] { "&macr;", "¯" };
			strArrays[19] = new string[] { "&deg;", "°" };
			strArrays[20] = new string[] { "&plusmn;", "±" };
			strArrays[21] = new string[] { "&sup2;", "²" };
			strArrays[22] = new string[] { "&sup3;", "³" };
			strArrays[23] = new string[] { "&acute;", "´" };
			strArrays[24] = new string[] { "&micro;", "µ" };
			strArrays[25] = new string[] { "&para;", "¶" };
			strArrays[26] = new string[] { "&middot;", "·" };
			strArrays[27] = new string[] { "&cedil;", "¸" };
			strArrays[28] = new string[] { "&sup1;", "¹" };
			strArrays[29] = new string[] { "&ordm;", "º" };
			strArrays[30] = new string[] { "&raquo;", "\u00a0»" };
			strArrays[31] = new string[] { "&frac14;", "¼" };
			strArrays[32] = new string[] { "&frac12;", "½" };
			strArrays[33] = new string[] { "&frac34;", "¾" };
			strArrays[34] = new string[] { "&iquest;", "¿" };
			strArrays[35] = new string[] { "&Agrave;", "À" };
			strArrays[36] = new string[] { "&Aacute;", "Á" };
			strArrays[37] = new string[] { "&Acirc;", "Â" };
			strArrays[38] = new string[] { "&Atilde;", "Ã" };
			strArrays[39] = new string[] { "&Auml;", "Ä" };
			strArrays[40] = new string[] { "&Aring;", "Å" };
			strArrays[41] = new string[] { "&AElig;", "Æ" };
			strArrays[42] = new string[] { "&Ccedil;", "Ç" };
			strArrays[43] = new string[] { "&Egrave;", "È" };
			strArrays[44] = new string[] { "&Eacute;", "É" };
			strArrays[45] = new string[] { "&Ecirc;", "Ê" };
			strArrays[46] = new string[] { "&Euml;", "Ë" };
			strArrays[47] = new string[] { "&Igrave;", "Ì" };
			strArrays[48] = new string[] { "&Iacute;", "Í" };
			strArrays[49] = new string[] { "&Icirc;", "Î" };
			strArrays[50] = new string[] { "&Iuml;", "Ï" };
			strArrays[51] = new string[] { "&ETH;", "Ð" };
			strArrays[52] = new string[] { "&Ntilde;", "Ñ" };
			strArrays[53] = new string[] { "&Ograve;", "Ò" };
			strArrays[54] = new string[] { "&Oacute;", "Ó" };
			strArrays[55] = new string[] { "&Ocirc;", "Ô" };
			strArrays[56] = new string[] { "&Otilde;", "Õ" };
			strArrays[57] = new string[] { "&Ouml;", "Ö" };
			strArrays[58] = new string[] { "&times;", "×" };
			strArrays[59] = new string[] { "&Oslash;", "Ø" };
			strArrays1 = new string[] { "&Ugrave;", "Ù" };
			strArrays[60] = strArrays1;
			strArrays1 = new string[] { "&Uacute;", "Ú" };
			strArrays[61] = strArrays1;
			strArrays1 = new string[] { "&Ucirc;", "Û" };
			strArrays[62] = strArrays1;
			strArrays1 = new string[] { "&Uuml;", "Ü" };
			strArrays[63] = strArrays1;
			strArrays1 = new string[] { "&Yacute;", "Ý" };
			strArrays[64] = strArrays1;
			strArrays1 = new string[] { "&THORN;", "Þ" };
			strArrays[65] = strArrays1;
			strArrays1 = new string[] { "&szlig;", "ß" };
			strArrays[66] = strArrays1;
			strArrays1 = new string[] { "&agrave;", "à" };
			strArrays[67] = strArrays1;
			strArrays1 = new string[] { "&aacute;", "á" };
			strArrays[68] = strArrays1;
			strArrays1 = new string[] { "&acirc;", "â" };
			strArrays[69] = strArrays1;
			strArrays1 = new string[] { "&atilde;", "ã" };
			strArrays[70] = strArrays1;
			strArrays1 = new string[] { "&auml;", "ä" };
			strArrays[71] = strArrays1;
			strArrays1 = new string[] { "&aring;", "å" };
			strArrays[72] = strArrays1;
			strArrays1 = new string[] { "&aelig;", "æ" };
			strArrays[73] = strArrays1;
			strArrays1 = new string[] { "&ccedil;", "ç" };
			strArrays[74] = strArrays1;
			strArrays1 = new string[] { "&egrave;", "è" };
			strArrays[75] = strArrays1;
			strArrays1 = new string[] { "&eacute;", "é" };
			strArrays[76] = strArrays1;
			strArrays1 = new string[] { "&ecirc;", "ê" };
			strArrays[77] = strArrays1;
			strArrays1 = new string[] { "&euml;", "ë" };
			strArrays[78] = strArrays1;
			strArrays1 = new string[] { "&igrave;", "ì" };
			strArrays[79] = strArrays1;
			strArrays1 = new string[] { "&iacute;", "í" };
			strArrays[80] = strArrays1;
			strArrays1 = new string[] { "&icirc;", "î" };
			strArrays[81] = strArrays1;
			strArrays1 = new string[] { "&iuml;", "ï" };
			strArrays[82] = strArrays1;
			strArrays1 = new string[] { "&eth;", "ð" };
			strArrays[83] = strArrays1;
			strArrays1 = new string[] { "&ntilde;", "ñ" };
			strArrays[84] = strArrays1;
			strArrays1 = new string[] { "&ograve;", "ò" };
			strArrays[85] = strArrays1;
			strArrays1 = new string[] { "&oacute;", "ó" };
			strArrays[86] = strArrays1;
			strArrays1 = new string[] { "&ocirc;", "ô" };
			strArrays[87] = strArrays1;
			strArrays1 = new string[] { "&otilde;", "õ" };
			strArrays[88] = strArrays1;
			strArrays1 = new string[] { "&ouml;", "ö" };
			strArrays[89] = strArrays1;
			strArrays1 = new string[] { "&divide;", "÷" };
			strArrays[90] = strArrays1;
			strArrays1 = new string[] { "&oslash;", "ø" };
			strArrays[91] = strArrays1;
			strArrays1 = new string[] { "&ugrave;", "ù" };
			strArrays[92] = strArrays1;
			strArrays1 = new string[] { "&uacute;", "ú" };
			strArrays[93] = strArrays1;
			strArrays1 = new string[] { "&ucirc;", "û" };
			strArrays[94] = strArrays1;
			strArrays1 = new string[] { "&uuml;", "ü" };
			strArrays[95] = strArrays1;
			strArrays1 = new string[] { "&yacute;", "ý" };
			strArrays[96] = strArrays1;
			strArrays1 = new string[] { "&thorn;", "þ" };
			strArrays[97] = strArrays1;
			strArrays1 = new string[] { "&yuml;", "ÿ" };
			strArrays[98] = strArrays1;
			strArrays1 = new string[] { "&OElig;", "Œ" };
			strArrays[99] = strArrays1;
			strArrays1 = new string[] { "&oelig;", "œ" };
			strArrays[100] = strArrays1;
			strArrays1 = new string[] { "&Scaron;", "Š" };
			strArrays[101] = strArrays1;
			strArrays1 = new string[] { "&scaron;", "š" };
			strArrays[102] = strArrays1;
			strArrays1 = new string[] { "&Yuml;", "Ÿ" };
			strArrays[103] = strArrays1;
			strArrays1 = new string[] { "&fnof;", "ƒ" };
			strArrays[104] = strArrays1;
			strArrays1 = new string[] { "&circ;", "ˆ" };
			strArrays[105] = strArrays1;
			strArrays1 = new string[] { "&tilde;", "˜" };
			strArrays[106] = strArrays1;
			strArrays1 = new string[] { "&Alpha;", "Α" };
			strArrays[107] = strArrays1;
			strArrays1 = new string[] { "&Beta;", "Β" };
			strArrays[108] = strArrays1;
			strArrays1 = new string[] { "&Gamma;", "Γ" };
			strArrays[109] = strArrays1;
			strArrays1 = new string[] { "&Delta;", "Δ" };
			strArrays[110] = strArrays1;
			strArrays1 = new string[] { "&Epsilon;", "Ε" };
			strArrays[111] = strArrays1;
			strArrays1 = new string[] { "&Zeta;", "Ζ" };
			strArrays[112] = strArrays1;
			strArrays1 = new string[] { "&Eta;", "Η" };
			strArrays[113] = strArrays1;
			strArrays1 = new string[] { "&Theta;", "Θ" };
			strArrays[114] = strArrays1;
			strArrays1 = new string[] { "&Iota;", "Ι" };
			strArrays[115] = strArrays1;
			strArrays1 = new string[] { "&Kappa;", "Κ" };
			strArrays[116] = strArrays1;
			strArrays1 = new string[] { "&Lambda;", "Λ" };
			strArrays[117] = strArrays1;
			strArrays1 = new string[] { "&Mu;", "Μ" };
			strArrays[118] = strArrays1;
			strArrays1 = new string[] { "&Nu;", "Ν" };
			strArrays[119] = strArrays1;
			strArrays1 = new string[] { "&Xi;", "Ξ" };
			strArrays[120] = strArrays1;
			strArrays1 = new string[] { "&Omicron;", "Ο" };
			strArrays[121] = strArrays1;
			strArrays1 = new string[] { "&Pi;", "Π" };
			strArrays[122] = strArrays1;
			strArrays1 = new string[] { "&Rho;", "Ρ" };
			strArrays[123] = strArrays1;
			strArrays1 = new string[] { "&Sigma;", "Σ" };
			strArrays[124] = strArrays1;
			strArrays1 = new string[] { "&Tau;", "Τ" };
			strArrays[125] = strArrays1;
			strArrays1 = new string[] { "&Upsilon;", "Υ" };
			strArrays[126] = strArrays1;
			strArrays1 = new string[] { "&Phi;", "Φ" };
			strArrays[127] = strArrays1;
			strArrays1 = new string[] { "&Chi;", "Χ" };
			strArrays[128] = strArrays1;
			strArrays1 = new string[] { "&Psi;", "Ψ" };
			strArrays[129] = strArrays1;
			strArrays1 = new string[] { "&Omega;", "Ω" };
			strArrays[130] = strArrays1;
			strArrays1 = new string[] { "&alpha;", "α" };
			strArrays[131] = strArrays1;
			strArrays1 = new string[] { "&beta;", "β" };
			strArrays[132] = strArrays1;
			strArrays1 = new string[] { "&gamma;", "γ" };
			strArrays[133] = strArrays1;
			strArrays1 = new string[] { "&delta;", "δ" };
			strArrays[134] = strArrays1;
			strArrays1 = new string[] { "&epsilon;", "ε" };
			strArrays[135] = strArrays1;
			strArrays1 = new string[] { "&zeta;", "ζ" };
			strArrays[136] = strArrays1;
			strArrays1 = new string[] { "&eta;", "η" };
			strArrays[137] = strArrays1;
			strArrays1 = new string[] { "&theta;", "θ" };
			strArrays[138] = strArrays1;
			strArrays1 = new string[] { "&iota;", "ι" };
			strArrays[139] = strArrays1;
			strArrays1 = new string[] { "&kappa;", "κ" };
			strArrays[140] = strArrays1;
			strArrays1 = new string[] { "&lambda;", "λ" };
			strArrays[141] = strArrays1;
			strArrays1 = new string[] { "&mu;", "μ" };
			strArrays[142] = strArrays1;
			strArrays1 = new string[] { "&nu;", "ν" };
			strArrays[143] = strArrays1;
			strArrays1 = new string[] { "&xi;", "ξ" };
			strArrays[144] = strArrays1;
			strArrays1 = new string[] { "&omicron;", "ο" };
			strArrays[145] = strArrays1;
			strArrays1 = new string[] { "&pi;", "π" };
			strArrays[146] = strArrays1;
			strArrays1 = new string[] { "&rho;", "ρ" };
			strArrays[147] = strArrays1;
			strArrays1 = new string[] { "&sigmaf;", "ς" };
			strArrays[148] = strArrays1;
			strArrays1 = new string[] { "&sigma;", "σ" };
			strArrays[149] = strArrays1;
			strArrays1 = new string[] { "&tau;", "τ" };
			strArrays[150] = strArrays1;
			strArrays1 = new string[] { "&upsilon;", "υ" };
			strArrays[151] = strArrays1;
			strArrays1 = new string[] { "&phi;", "φ" };
			strArrays[152] = strArrays1;
			strArrays1 = new string[] { "&chi;", "χ" };
			strArrays[153] = strArrays1;
			strArrays1 = new string[] { "&psi;", "ψ" };
			strArrays[154] = strArrays1;
			strArrays1 = new string[] { "&omega;", "ω" };
			strArrays[155] = strArrays1;
			strArrays1 = new string[] { "&thetasym;", "ϑ" };
			strArrays[156] = strArrays1;
			strArrays1 = new string[] { "&upsih;", "ϒ" };
			strArrays[157] = strArrays1;
			strArrays1 = new string[] { "&piv;", "ϖ" };
			strArrays[158] = strArrays1;
			strArrays1 = new string[] { "&ensp;", "\u2002" };
			strArrays[159] = strArrays1;
			strArrays1 = new string[] { "&emsp;", "\u2003" };
			strArrays[160] = strArrays1;
			strArrays1 = new string[] { "&thinsp;", "\u2009" };
			strArrays[161] = strArrays1;
			strArrays1 = new string[] { "&zwnj;", "‌" };
			strArrays[162] = strArrays1;
			strArrays1 = new string[] { "&zwj;", "‍" };
			strArrays[163] = strArrays1;
			strArrays1 = new string[] { "&lrm;", "‎" };
			strArrays[164] = strArrays1;
			strArrays1 = new string[] { "&rlm;", "‏" };
			strArrays[165] = strArrays1;
			strArrays1 = new string[] { "&ndash;", "–" };
			strArrays[166] = strArrays1;
			strArrays1 = new string[] { "&mdash;", "—" };
			strArrays[167] = strArrays1;
			strArrays1 = new string[] { "&lsquo;", "‘" };
			strArrays[168] = strArrays1;
			strArrays1 = new string[] { "&rsquo;", "’" };
			strArrays[169] = strArrays1;
			strArrays1 = new string[] { "&sbquo;", "‚" };
			strArrays[170] = strArrays1;
			strArrays1 = new string[] { "&ldquo;", "“" };
			strArrays[171] = strArrays1;
			strArrays1 = new string[] { "&rdquo;", "”" };
			strArrays[172] = strArrays1;
			strArrays1 = new string[] { "&bdquo;", "„" };
			strArrays[173] = strArrays1;
			strArrays1 = new string[] { "&dagger;", "†" };
			strArrays[174] = strArrays1;
			strArrays1 = new string[] { "&Dagger;", "‡" };
			strArrays[175] = strArrays1;
			strArrays1 = new string[] { "&bull;", "•" };
			strArrays[176] = strArrays1;
			strArrays1 = new string[] { "&hellip;", "…" };
			strArrays[177] = strArrays1;
			strArrays1 = new string[] { "&permil;", "‰" };
			strArrays[178] = strArrays1;
			strArrays1 = new string[] { "&prime;", "′" };
			strArrays[179] = strArrays1;
			strArrays1 = new string[] { "&Prime;", "″" };
			strArrays[180] = strArrays1;
			strArrays1 = new string[] { "&lsaquo;", "‹" };
			strArrays[181] = strArrays1;
			strArrays1 = new string[] { "&rsaquo;", "›" };
			strArrays[182] = strArrays1;
			strArrays1 = new string[] { "&oline;", "‾" };
			strArrays[183] = strArrays1;
			strArrays1 = new string[] { "&frasl;", "⁄" };
			strArrays[184] = strArrays1;
			strArrays1 = new string[] { "&euro;", "€" };
			strArrays[185] = strArrays1;
			strArrays1 = new string[] { "&image;", "ℑ" };
			strArrays[186] = strArrays1;
			strArrays1 = new string[] { "&weierp;", "℘" };
			strArrays[187] = strArrays1;
			strArrays1 = new string[] { "&real;", "ℜ" };
			strArrays[188] = strArrays1;
			strArrays1 = new string[] { "&trade;", "™" };
			strArrays[189] = strArrays1;
			strArrays1 = new string[] { "&alefsym;", "ℵ" };
			strArrays[190] = strArrays1;
			strArrays1 = new string[] { "&larr;", "←" };
			strArrays[191] = strArrays1;
			strArrays1 = new string[] { "&uarr;", "↑" };
			strArrays[192] = strArrays1;
			strArrays1 = new string[] { "&rarr;", "→" };
			strArrays[193] = strArrays1;
			strArrays1 = new string[] { "&darr;", "↓" };
			strArrays[194] = strArrays1;
			strArrays1 = new string[] { "&harr;", "↔" };
			strArrays[195] = strArrays1;
			strArrays1 = new string[] { "&crarr;", "↵" };
			strArrays[196] = strArrays1;
			strArrays1 = new string[] { "&lArr;", "⇐" };
			strArrays[197] = strArrays1;
			strArrays1 = new string[] { "&uArr;", "⇑" };
			strArrays[198] = strArrays1;
			strArrays1 = new string[] { "&rArr;", "⇒" };
			strArrays[199] = strArrays1;
			strArrays1 = new string[] { "&dArr;", "⇓" };
			strArrays[200] = strArrays1;
			strArrays1 = new string[] { "&hArr;", "⇔" };
			strArrays[201] = strArrays1;
			strArrays1 = new string[] { "&forall;", "∀" };
			strArrays[202] = strArrays1;
			strArrays1 = new string[] { "&part;", "∂" };
			strArrays[203] = strArrays1;
			strArrays1 = new string[] { "&exist;", "∃" };
			strArrays[204] = strArrays1;
			strArrays1 = new string[] { "&empty;", "∅" };
			strArrays[205] = strArrays1;
			strArrays1 = new string[] { "&nabla;", "∇" };
			strArrays[206] = strArrays1;
			strArrays1 = new string[] { "&isin;", "∈" };
			strArrays[207] = strArrays1;
			strArrays1 = new string[] { "&notin;", "∉" };
			strArrays[208] = strArrays1;
			strArrays1 = new string[] { "&ni;", "∋" };
			strArrays[209] = strArrays1;
			strArrays1 = new string[] { "&prod;", "∏" };
			strArrays[210] = strArrays1;
			strArrays1 = new string[] { "&sum;", "∑" };
			strArrays[211] = strArrays1;
			strArrays1 = new string[] { "&minus;", "−" };
			strArrays[212] = strArrays1;
			strArrays1 = new string[] { "&lowast;", "∗" };
			strArrays[213] = strArrays1;
			strArrays1 = new string[] { "&radic;", "√" };
			strArrays[214] = strArrays1;
			strArrays1 = new string[] { "&prop;", "∝" };
			strArrays[215] = strArrays1;
			strArrays1 = new string[] { "&infin;", "∞" };
			strArrays[216] = strArrays1;
			strArrays1 = new string[] { "&ang;", "∠" };
			strArrays[217] = strArrays1;
			strArrays1 = new string[] { "&and;", "∧" };
			strArrays[218] = strArrays1;
			strArrays1 = new string[] { "&or;", "∨" };
			strArrays[219] = strArrays1;
			strArrays1 = new string[] { "&cap;", "∩" };
			strArrays[220] = strArrays1;
			strArrays1 = new string[] { "&cup;", "∪" };
			strArrays[221] = strArrays1;
			strArrays1 = new string[] { "&int;", "∫" };
			strArrays[222] = strArrays1;
			strArrays1 = new string[] { "&there4;", "∴" };
			strArrays[223] = strArrays1;
			strArrays1 = new string[] { "&sim;", "∼" };
			strArrays[224] = strArrays1;
			strArrays1 = new string[] { "&cong;", "≅" };
			strArrays[225] = strArrays1;
			strArrays1 = new string[] { "&asymp;", "≈" };
			strArrays[226] = strArrays1;
			strArrays1 = new string[] { "&ne;", "≠" };
			strArrays[227] = strArrays1;
			strArrays1 = new string[] { "&equiv;", "≡" };
			strArrays[228] = strArrays1;
			strArrays1 = new string[] { "&le;", "≤" };
			strArrays[229] = strArrays1;
			strArrays1 = new string[] { "&ge;", "≥" };
			strArrays[230] = strArrays1;
			strArrays1 = new string[] { "&sub;", "⊂" };
			strArrays[231] = strArrays1;
			strArrays1 = new string[] { "&sup;", "⊃" };
			strArrays[232] = strArrays1;
			strArrays1 = new string[] { "&nsub;", "⊄" };
			strArrays[233] = strArrays1;
			strArrays1 = new string[] { "&sube;", "⊆" };
			strArrays[234] = strArrays1;
			strArrays1 = new string[] { "&supe;", "⊇" };
			strArrays[235] = strArrays1;
			strArrays1 = new string[] { "&oplus;", "⊕" };
			strArrays[236] = strArrays1;
			strArrays1 = new string[] { "&otimes;", "⊗" };
			strArrays[237] = strArrays1;
			strArrays1 = new string[] { "&perp;", "⊥" };
			strArrays[238] = strArrays1;
			strArrays1 = new string[] { "&sdot;", "⋅" };
			strArrays[239] = strArrays1;
			strArrays1 = new string[] { "&lceil;", "⌈" };
			strArrays[240] = strArrays1;
			strArrays1 = new string[] { "&rceil;", "⌉" };
			strArrays[241] = strArrays1;
			strArrays1 = new string[] { "&lfloor;", "⌊" };
			strArrays[242] = strArrays1;
			strArrays1 = new string[] { "&rfloor;", "⌋" };
			strArrays[243] = strArrays1;
			strArrays1 = new string[] { "&lang;", "〈" };
			strArrays[244] = strArrays1;
			strArrays1 = new string[] { "&rang;", "〉" };
			strArrays[245] = strArrays1;
			strArrays1 = new string[] { "&loz;", "◊" };
			strArrays[246] = strArrays1;
			strArrays1 = new string[] { "&spades;", "♠" };
			strArrays[247] = strArrays1;
			strArrays1 = new string[] { "&clubs;", "♣" };
			strArrays[248] = strArrays1;
			strArrays1 = new string[] { "&hearts;", "♥" };
			strArrays[249] = strArrays1;
			strArrays1 = new string[] { "&diams;", "♦" };
			strArrays[250] = strArrays1;
			HtmlHelper.htmlNamedEntities = strArrays;
		}

		public HtmlHelper()
		{
		}

		public static string HtmlStripTags(string htmlContent, bool replaceNamedEntities, bool replaceNumberedEntities)
		{
			if (htmlContent == null)
			{
				return null;
			}
			htmlContent = htmlContent.Trim();
			if (htmlContent == string.Empty)
			{
				return string.Empty;
			}
			int num = htmlContent.IndexOf("<body", StringComparison.CurrentCultureIgnoreCase);
			int num1 = htmlContent.IndexOf("</body>", StringComparison.CurrentCultureIgnoreCase);
			int num2 = 0;
			int length = htmlContent.Length - 1;
			if (num >= 0)
			{
				num2 = num;
			}
			if (num1 >= 0)
			{
				length = num1;
			}
			bool flag = false;
			bool flag1 = false;
			bool flag2 = false;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			char chr = '\"';
			StringBuilder stringBuilder = new StringBuilder(htmlContent.Length);
			for (int i = num2; i <= length; i++)
			{
				if (flag2)
				{
					if (i + 2 < htmlContent.Length && htmlContent[i] == '-' && htmlContent[i + 1] == '-' && htmlContent[i + 2] == '>')
					{
						i = i + 2;
						flag2 = false;
					}
				}
				else if (i + 3 < htmlContent.Length && htmlContent[i] == '<' && htmlContent[i + 1] == '!' && htmlContent[i + 2] == '-' && htmlContent[i + 3] == '-')
				{
					i = i + 3;
					flag2 = true;
				}
				else if (flag4)
				{
					if (i + 10 < htmlContent.Length && htmlContent[i] == '<' && htmlContent[i + 1] == '/' && (htmlContent[i + 2] == 'n' || htmlContent[i + 2] == 'N') && (htmlContent[i + 3] == 'o' || htmlContent[i + 3] == 'O') && (htmlContent[i + 4] == 's' || htmlContent[i + 4] == 'S') && (htmlContent[i + 5] == 'c' || htmlContent[i + 5] == 'C') && (htmlContent[i + 6] == 'r' || htmlContent[i + 6] == 'R') && (htmlContent[i + 7] == 'i' || htmlContent[i + 7] == 'I') && (htmlContent[i + 8] == 'p' || htmlContent[i + 8] == 'P') && (htmlContent[i + 9] == 't' || htmlContent[i + 9] == 'T') && (char.IsWhiteSpace(htmlContent[i + 10]) || htmlContent[i + 10] == '>'))
					{
						if (htmlContent[i + 10] == '>')
						{
							i = i + 10;
						}
						else
						{
							i = i + 9;
							while (i < htmlContent.Length)
							{
								if (htmlContent[i] != '>')
								{
									i++;
								}
								else
								{
									break;
								}
							}
						}
						flag4 = false;
					}
				}
				else if (i + 9 < htmlContent.Length && htmlContent[i] == '<' && (htmlContent[i + 1] == 'n' || htmlContent[i + 1] == 'N') && (htmlContent[i + 2] == 'o' || htmlContent[i + 2] == 'O') && (htmlContent[i + 3] == 's' || htmlContent[i + 3] == 'S') && (htmlContent[i + 4] == 'c' || htmlContent[i + 4] == 'C') && (htmlContent[i + 5] == 'r' || htmlContent[i + 5] == 'R') && (htmlContent[i + 6] == 'i' || htmlContent[i + 6] == 'I') && (htmlContent[i + 7] == 'p' || htmlContent[i + 7] == 'P') && (htmlContent[i + 8] == 't' || htmlContent[i + 8] == 'T') && (char.IsWhiteSpace(htmlContent[i + 9]) || htmlContent[i + 9] == '>'))
				{
					i = i + 9;
					flag4 = true;
				}
				else if (flag3)
				{
					if (i + 8 < htmlContent.Length && htmlContent[i] == '<' && htmlContent[i + 1] == '/' && (htmlContent[i + 2] == 's' || htmlContent[i + 2] == 'S') && (htmlContent[i + 3] == 'c' || htmlContent[i + 3] == 'C') && (htmlContent[i + 4] == 'r' || htmlContent[i + 4] == 'R') && (htmlContent[i + 5] == 'i' || htmlContent[i + 5] == 'I') && (htmlContent[i + 6] == 'p' || htmlContent[i + 6] == 'P') && (htmlContent[i + 7] == 't' || htmlContent[i + 7] == 'T') && (char.IsWhiteSpace(htmlContent[i + 8]) || htmlContent[i + 8] == '>'))
					{
						if (htmlContent[i + 8] == '>')
						{
							i = i + 8;
						}
						else
						{
							i = i + 7;
							while (i < htmlContent.Length)
							{
								if (htmlContent[i] != '>')
								{
									i++;
								}
								else
								{
									break;
								}
							}
						}
						flag3 = false;
					}
				}
				else if (i + 7 < htmlContent.Length && htmlContent[i] == '<' && (htmlContent[i + 1] == 's' || htmlContent[i + 1] == 'S') && (htmlContent[i + 2] == 'c' || htmlContent[i + 2] == 'C') && (htmlContent[i + 3] == 'r' || htmlContent[i + 3] == 'R') && (htmlContent[i + 4] == 'i' || htmlContent[i + 4] == 'I') && (htmlContent[i + 5] == 'p' || htmlContent[i + 5] == 'P') && (htmlContent[i + 6] == 't' || htmlContent[i + 6] == 'T') && (char.IsWhiteSpace(htmlContent[i + 7]) || htmlContent[i + 7] == '>'))
				{
					i = i + 6;
					flag3 = true;
				}
				else if (flag5)
				{
					if (i + 8 < htmlContent.Length && htmlContent[i] == '<' && htmlContent[i + 1] == '/' && (htmlContent[i + 2] == 's' || htmlContent[i + 2] == 'S') && (htmlContent[i + 3] == 't' || htmlContent[i + 3] == 'C') && (htmlContent[i + 4] == 'y' || htmlContent[i + 4] == 'R') && (htmlContent[i + 5] == 'l' || htmlContent[i + 5] == 'I') && (htmlContent[i + 6] == 'e' || htmlContent[i + 6] == 'P') && (char.IsWhiteSpace(htmlContent[i + 7]) || htmlContent[i + 7] == '>'))
					{
						if (htmlContent[i + 7] == '>')
						{
							i = i + 7;
						}
						else
						{
							i = i + 7;
							while (i < htmlContent.Length)
							{
								if (htmlContent[i] != '>')
								{
									i++;
								}
								else
								{
									break;
								}
							}
						}
						flag5 = false;
					}
				}
				else if (i + 7 < htmlContent.Length && htmlContent[i] == '<' && (htmlContent[i + 1] == 's' || htmlContent[i + 1] == 'S') && (htmlContent[i + 2] == 't' || htmlContent[i + 2] == 'T') && (htmlContent[i + 3] == 'y' || htmlContent[i + 3] == 'Y') && (htmlContent[i + 4] == 'l' || htmlContent[i + 4] == 'L') && (htmlContent[i + 5] == 'e' || htmlContent[i + 5] == 'E') && (char.IsWhiteSpace(htmlContent[i + 6]) || htmlContent[i + 6] == '>'))
				{
					i = i + 5;
					flag5 = true;
				}
				else if (!flag)
				{
					if (i >= htmlContent.Length || htmlContent[i] != '<')
					{
						stringBuilder.Append(htmlContent[i]);
					}
					else
					{
						flag = true;
					}
				}
				else if (flag1)
				{
					if (htmlContent[i] == chr)
					{
						flag1 = false;
					}
				}
				else if (htmlContent[i] == '\"' || htmlContent[i] == '\'')
				{
					chr = htmlContent[i];
					flag1 = true;
				}
				else if (htmlContent[i] == '>')
				{
					flag = false;
					stringBuilder.Append(' ');
				}
			}
			if (replaceNamedEntities)
			{
				string[][] strArrays = HtmlHelper.htmlNamedEntities;
				for (int j = 0; j < (int)strArrays.Length; j++)
				{
					string[] strArrays1 = strArrays[j];
					stringBuilder.Replace(strArrays1[0], strArrays1[1]);
				}
			}
			if (replaceNumberedEntities)
			{
				for (int k = 0; k < 512; k++)
				{
					string str = string.Concat("&#", k, ";");
					char chr1 = (char)k;
					stringBuilder.Replace(str, chr1.ToString());
				}
			}
			return stringBuilder.ToString();
		}

		public static string replaceTags(string str)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(str);
			stringBuilder.Replace("select", "");
			stringBuilder.Replace("SELECT", "");
			stringBuilder.Replace("drop", "");
			stringBuilder.Replace("DROP", "");
			stringBuilder.Replace("delete", "");
			stringBuilder.Replace("DELETE", "");
			stringBuilder.Replace("insert", "");
			stringBuilder.Replace("INSERT", "");
			stringBuilder.Replace("crm_", "");
			stringBuilder.Replace("CRM_", "");
			return stringBuilder.ToString();
		}
	}
}