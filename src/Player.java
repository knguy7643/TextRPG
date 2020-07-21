
public class Player {

	private Class playerClass;
	private Ability[] abilities = new Ability[4];
	private String playerName;
	private int totalExp;
	
	private final int MAX_MANA = 4;
	
	//Stats
	private int currentHP;
	private int maxHP;
	private int manaPool;
	private int atk;
	private int def;
	private int agility;
	
	public Player(String name, Class playerClass) {
		playerName = name;
		
		this.playerClass = playerClass;
		
		totalExp = 0;
		
		setMana();
		
		
		
		currentHP = maxHP;
	}
	
	public void reset() {
		currentHP = maxHP;
		
		setMana();
		
	}
	
	public void setMana() {
		if (this.playerClass == Class.Force) {
			manaPool = 1;
		}
		else {
			manaPool = 0;
		}
	}
	
}
