<Query Kind="Statements" />

string classname = "SecurityCategories";
List<string> props = new List<string>{
	"designid",
"designnumber",
"companyid",
"description",
"imagefilename",
"dateadded",
"companyid1",
"gafyid",
"companyname",
"companycontactemail",
"companycontactphone",
"canpickup",
};

string.Format("public class {0} : IEquatable<{0}>", classname).Dump();
"{".Dump();

//properties
foreach (var p in props)
{
	("	public int "+ p +" { get; set; }").Dump();
}
" ".Dump();

//Equatable Method
string.Format("	public bool Equals([AllowNull] {0} other)",classname).Dump();
"	{".Dump();
"		if (ReferenceEquals(other, null))".Dump();
"			return false;".Dump();
"		if (ReferenceEquals(other, null))".Dump();
"			return true;".Dump();
foreach(var p in props)
{
	if(props.IndexOf(p) == 0)
	{
		string.Format("			return {0}.Equals(other.{0})", p).Dump();
	}
	else
	{
		string.Format("				&& {0}.Equals(other.{0})",p).Dump();
	}
	
}
"	}".Dump();
"}".Dump();