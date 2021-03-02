namespace FootballTeamGenerator
{
    public class Player
    {
        //Aaron_Ramsey;95;82;82;89;68
        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }
        private const int minStat = 0;
        private const int maxStat = 100;

        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public int Endurance
        {
            get => endurance;
            private set
            {
                Validator.ThrowInvalidValue(value, minStat, maxStat, "Endurance should be between 0 and 100.");
                endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            private set
            {
                Validator.ThrowInvalidValue(value, minStat, maxStat, "Sprint should be between 0 and 100.");
                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            private set
            {
                Validator.ThrowInvalidValue(value, minStat, maxStat, "Dribble should be between 0 and 100.");
                dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            private set
            {
                Validator.ThrowInvalidValue(value, minStat, maxStat, "Passing should be between 0 and 100.");
                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                Validator.ThrowInvalidValue(value, minStat, maxStat, "Shooting should be between 0 and 100.");
                shooting = value;
            }
        }
        public string Name
        {
            get => name;
            private set
            {
                Validator.ThrowEmptyName(value, "A name should not be empty.");
                name = value;
            }
        }

        public double Overall { get => (Endurance + Sprint + Shooting + Passing + Dribble) / 5.0; }
    }
}