import java.util.NavigableMap;
import java.util.TreeMap;

public class Player {

	private Class playerClass;
	private Ability[] abilities = new Ability[4];
	private String playerName;
	private int currExp;
	private int level;
	
	private final int MAX_MANA = 4;
	
	//Stats
	private int currentHP;
	private int maxHP;
	private int manaPool;
	private int atk;
	private int def;
	private int agility;
	
	private static NavigableMap<Integer, Integer> EXP_NEEDED_FOR_LVL = new TreeMap<>();
	
	static {
		EXP_NEEDED_FOR_LVL.put(15, 2);
		for (int lvl = 3; lvl < 50; lvl++) {
			int exp = 15;
			EXP_NEEDED_FOR_LVL.put((lvl) * exp, lvl);
		}
	}
	
	public Player(String name, Class playerClass) {
		this.playerName = name;
		
		this.playerClass = playerClass;
		
		this.currExp = 0;
		
		this.level = 1;
		
		setMana();
		
		int[] temp = playerClass.getStats();
		
		this.maxHP = temp[0];
		
		this.atk = temp[1];
		
		this.def = temp[2];
		
		this.agility = temp[3];
		
		currentHP = maxHP;
	}
	
	public void reset() {
		currentHP = maxHP;
		
		setMana();
		
	}
	
	public int getLvl() {
		return this.level;
	}
	
	public void setMana() {
		if (this.playerClass == Class.Force) {
			this.manaPool = 1;
		}
		else {
			this.manaPool = 0;
		}
	}
	
	public int getAgility() {
		return this.agility;
	}
	
	public void levelUp() {
		
		this.level++;
		
		int[] statBonus = this.playerClass.levelUpBonus();
		
		this.maxHP = this.maxHP + statBonus[0] * (this.level);
		
		this.atk = this.atk + statBonus[1] * (this.level);
		
		this.def = this.def + statBonus[2] * (this.level);
		
		this.agility = this.agility + statBonus[3] * (this.level);
		
		this.reset();
		
	}
	
	public int getAttack() {
		return this.atk;
	}
	
	public int getDefense() {
		return this.def;
	}
	
	public int getHP() {
		return this.currentHP;
	}
	
	public void levelCheck() {
		int temp = EXP_NEEDED_FOR_LVL.lowerKey(this.currExp);
		
		if (temp != this.level) {
			this.levelUp();
			
			this.currExp = 0;
		}
		
	}
	
	public void gainExp(int num) {
		this.currExp = this.currExp + num;
		
		this.levelCheck();
	}
	
	public boolean isEmpty() {
		for (int idx = 0; idx < abilities.length; idx++) {
			if (abilities[idx] == null) {
				return true;
			}
		}
		return false;
	}
	
	public void learnAbility(Ability ability) {
		if (this.isEmpty()) {
			for (int idx = 0; idx < abilities.length; idx++) {
				if (abilities[idx] == null) {
					abilities[idx] = ability;
				}
			}
		}
		else {
			//Repleace an ability
		}
		
	}
	
}
