using System;

namespace Setting
{
	public class SettingKeyList
	{
		public readonly static string UNKNOWN_KEY_NAME;

		public readonly static string NONE_KEY_NAME;

		public readonly static int NONE_KEY_CODE;

		public readonly static SettingKey[] key_list;

		static SettingKeyList()
		{
			SettingKeyList.UNKNOWN_KEY_NAME = "不明なキー";
			SettingKeyList.NONE_KEY_NAME = "";
			SettingKeyList.NONE_KEY_CODE = 0;
			SettingKey[] settingKey = new SettingKey[] { new SettingKey(SettingKeyList.NONE_KEY_CODE, SettingKeyList.NONE_KEY_NAME, true), new SettingKey(1, "Esc", false), new SettingKey(2, "1", true), new SettingKey(3, "2", true), new SettingKey(4, "3", true), new SettingKey(5, "4", true), new SettingKey(6, "5", true), new SettingKey(7, "6", true), new SettingKey(8, "7", true), new SettingKey(9, "8", true), new SettingKey(10, "9", true), new SettingKey(11, "0", true), new SettingKey(12, "-", true), new SettingKey(13, "=", true), new SettingKey(14, "Back Space", true), new SettingKey(15, "Tab", true), new SettingKey(16, "Q", true), new SettingKey(17, "W", true), new SettingKey(18, "E", true), new SettingKey(19, "R", true), new SettingKey(20, "T", true), new SettingKey(21, "Y", true), new SettingKey(22, "U", true), new SettingKey(23, "I", true), new SettingKey(24, "O", true), new SettingKey(25, "P", true), new SettingKey(26, "[", true), new SettingKey(27, "]", true), new SettingKey(28, "Enter (固定割り当て)", false), new SettingKey(29, "Ctrl (左)", true), new SettingKey(30, "A", true), new SettingKey(31, "S", true), new SettingKey(32, "D", true), new SettingKey(33, "F", true), new SettingKey(34, "G", true), new SettingKey(35, "H", true), new SettingKey(36, "J", true), new SettingKey(37, "K", true), new SettingKey(38, "L", true), new SettingKey(39, ";", true), new SettingKey(40, "'", true), new SettingKey(41, "`", true), new SettingKey(42, "Shift (左)", true), new SettingKey(43, "\\", true), new SettingKey(44, "Z", true), new SettingKey(45, "X", true), new SettingKey(46, "C", true), new SettingKey(47, "V", true), new SettingKey(48, "B", true), new SettingKey(49, "N", true), new SettingKey(50, "M", true), new SettingKey(51, ",", true), new SettingKey(52, ".", true), new SettingKey(53, "/", true), new SettingKey(54, "Shift (右)", true), new SettingKey(55, "* (Numpad)", false), new SettingKey(56, "Alt (左)", true), new SettingKey(57, "Space", true), new SettingKey(58, "Caps Lock", false), new SettingKey(59, "F1", false), new SettingKey(60, "F2", false), new SettingKey(61, "F3", false), new SettingKey(62, "F4", false), new SettingKey(63, "F5", false), new SettingKey(64, "F6", false), new SettingKey(65, "F7", false), new SettingKey(66, "F8", false), new SettingKey(67, "F9", false), new SettingKey(68, "F10", false), new SettingKey(69, "Num Lock", false), new SettingKey(70, "Scroll Lock", false), new SettingKey(71, "7 (Numpad)", false), new SettingKey(72, "8 (Numpad)", false), new SettingKey(73, "9 (Numpad)", false), new SettingKey(74, "- (Numpad)", false), new SettingKey(75, "4 (Numpad)", false), new SettingKey(76, "5 (Numpad)", false), new SettingKey(77, "6 (Numpad)", false), new SettingKey(78, "+ (Numpad)", false), new SettingKey(79, "1 (Numpad)", false), new SettingKey(80, "2 (Numpad)", false), new SettingKey(81, "3 (Numpad)", false), new SettingKey(82, "0 (Numpad)", false), new SettingKey(83, ". (Numpad)", false), new SettingKey(87, "F11", false), new SettingKey(88, "F12", false), new SettingKey(100, "F13 NEC PC-98", false), new SettingKey(101, "F14 NEC PC-98", false), new SettingKey(102, "F15 NEC PC-98", false), new SettingKey(112, "カナ 日本語キーボード", false), new SettingKey(121, "変換 日本語キーボード", true), new SettingKey(123, "無変換 日本語キーボード", true), new SettingKey(125, "\\ 日本語キーボード", true), new SettingKey(141, "= NEC PC-98", true), new SettingKey(144, "^ 日本語キーボード", true), new SettingKey(145, "@ NEC PC-98", true), new SettingKey(146, ": NEC PC-98", true), new SettingKey(147, "_ NEC PC-98", true), new SettingKey(148, "漢字 日本語キーボード", false), new SettingKey(149, "Stop NEC PC-98", true), new SettingKey(150, "(Japan AX)", true), new SettingKey(151, "(J3100)", true), new SettingKey(156, "Enter (Numpad)", false), new SettingKey(157, "Ctrl (右)", true), new SettingKey(179, ", (Numpad) NEC PC-98", false), new SettingKey(181, "/ (Numpad)", false), new SettingKey(183, "Sys Rq", false), new SettingKey(184, "Alt (右)", true), new SettingKey(197, "Pause", false), new SettingKey(199, "Home", false), new SettingKey(200, "↑", false), new SettingKey(201, "Page Up", false), new SettingKey(203, "←", false), new SettingKey(205, "→", false), new SettingKey(207, "End", false), new SettingKey(208, "↓", false), new SettingKey(209, "Page Down", false), new SettingKey(210, "Insert", false), new SettingKey(211, "Delete", false), new SettingKey(219, "Windows", true), new SettingKey(220, "Windows", true), new SettingKey(221, "Menu", true), new SettingKey(222, "Power", false), new SettingKey(223, "Windows", false), new SettingKey(227, "System Wake", false), new SettingKey(229, "Web Search", false), new SettingKey(230, "Web Favorites", false), new SettingKey(231, "Web Refresh", false), new SettingKey(232, "Web Stop", false), new SettingKey(233, "Web Forward", false), new SettingKey(234, "Web Back", false), new SettingKey(235, "My Computer", false), new SettingKey(236, "Mail", false), new SettingKey(237, "Media Select", false) };
			SettingKeyList.key_list = settingKey;
		}

		public SettingKeyList()
		{
		}

		public static SettingKey Get(int key_code)
		{
			SettingKey[] keyList = SettingKeyList.key_list;
			for (int i = 0; i < (int)keyList.Length; i++)
			{
				SettingKey settingKey = keyList[i];
				if (settingKey.keycode == key_code)
				{
					return settingKey;
				}
			}
			return new SettingKey(key_code, SettingKeyList.UNKNOWN_KEY_NAME, false);
		}

		public static SettingKey Get(string key_name)
		{
			SettingKey[] keyList = SettingKeyList.key_list;
			for (int i = 0; i < (int)keyList.Length; i++)
			{
				SettingKey settingKey = keyList[i];
				if (settingKey.name == key_name)
				{
					return settingKey;
				}
			}
			return new SettingKey(0, SettingKeyList.NONE_KEY_NAME, false);
		}
	}
}