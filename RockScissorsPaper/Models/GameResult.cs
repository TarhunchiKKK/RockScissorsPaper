using System.Runtime.Serialization;


namespace RockScissorsPaper.Models
{
    internal enum GameResult
    {
        [EnumMember(Value = "Win")]
        Win,

        [EnumMember(Value = "Lose")]
        Lose,

        [EnumMember(Value = "Draw")]
        Draw
    }
}
