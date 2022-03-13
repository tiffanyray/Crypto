using System.Runtime.Serialization;

namespace Application.Communication
{
    public enum CrudActions
    {
        [EnumMember(Value = "getting")]
        Getting = 1,
        [EnumMember(Value = "saving")]
        Saving = 2,
        [EnumMember(Value = "updating")]
        Updating = 3,
        [EnumMember(Value = "deleting")]
        Deleting = 4
    }
}