import java.util.HashMap;

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
	
	private static HashMap<Integer, Integer> EXP_NEEDED_FOR_LVL = new HashMap<>();
	
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
	
	public void levelCheck() {
		int temp = this.totalExp;
		
		
	}
	
}
