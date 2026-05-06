using System;

[Flags]
public enum GridSettingsType
{
	Paging = 1,
	Sorting = 2,
	Filtering = 4,
	Grouping = 8,
	ColumnSettings = 16,
	All = 32
}