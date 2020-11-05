namespace Dochazka.Utils {
    public enum PresenceType {
        Present = 0,
        Absent = 1,
        Excused = 2
    }

    public static class PresenceTypeEnum {
        public static string ToString(PresenceType type, bool symbolic = false) {
            switch (type) {
                case PresenceType.Absent:
                    if (symbolic) return "X";
                    return "Nepřítomen";
                case PresenceType.Excused:
                    if (symbolic) return "O";
                    return "Omluven";
                case PresenceType.Present:
                    if (symbolic) return "/";
                    return "Přítomen";
                default:
                    return "";
            }
        }
    }
}