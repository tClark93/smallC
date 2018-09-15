namespace Human {
    public class Human{
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;
        public Human (string enteredName){
            name = enteredName;
        }
        public Human (string enteredName, int enteredStrength, int enteredIntelligence, int enteredDexterity, int enteredHealth) {
            name = enteredName;
            strength = enteredStrength;
            intelligence = enteredIntelligence;
            dexterity = enteredDexterity;
            health = enteredHealth;
        }
        public void Attack(Human victim) {
            victim.health -= strength * 3;
        }
    }
}