import java.util.HashMap;
import java.util.TreeMap;
import java.util.TreeSet;

public class Player {

	private String name;
	private CharacterClass type;
	private int level;
	private int totalExp;
	private int currentHP;
	private int maxHP;
	private static TreeMap<Integer, Integer> EXP_TO_LEVEL = new TreeMap<>();
	private static TreeMap<Integer, Integer> LEVEL_TO_HP = new TreeMap<>();
	private static TreeMap<Integer, Integer> LEVEL_TO_ATK = new TreeMap<>();
	private static TreeMap<Integer, Integer> LEVEL_TO_DEF = new TreeMap<>();
	
	static {
		
		LEVEL_TO_HP.put(1, 10);
		LEVEL_TO_ATK.put(1, 10);
	}
	
	public Player() {
		
		this.name = "";
		
		this.type = CharacterClass.NONE;
		
		this.level = 1;
		
		this.totalExp = 0;
		
		this.currentHP = LEVEL_TO_HP.get(level);
		
		this.maxHP = LEVEL_TO_HP.get(level);
	}
	
	public Player(String name, CharacterClass type) {
		
		this.name = name;
		
		this.type = type;
		
		this.maxHP = this.currentHP = 10;
		
		this.level = 1;
		
		this.totalExp = 0;
		
	}
	
	public Player(String name, CharacterClass type, int level, int totalExp, int curHP) {
		
		this.name = name;
		
		this.type = type;
		
		this.level = level;
		
		this.totalExp = totalExp;
		
		this.currentHP = curHP;
		
		this.maxHP = LEVEL_TO_HP.get(level);
		
	}
	
	public String getName() {
		return this.name;
	}
	
	public String getStringClass() {
		return this.type.toString();
	}
	
	public int getTotalExp() {
		return this.totalExp;
	}
	
	public int getLevel() {
		return this.level;
	}
	
	public int getCurrentHP() {
		return this.currentHP;
	}
	
	public int getMaxHP() {
		return this.maxHP;
	}
	
	public int getAtk() {
		return LEVEL_TO_ATK.get(this.level);
	}
	
	public int getDef() {
		return LEVEL_TO_ATK.get(this.level);
	}
	
	public void newLevel() {
		
		int temp = this.getTotalExp();

		this.level = EXP_TO_LEVEL.get(EXP_TO_LEVEL.floorKey(temp));
		
	}
	
	public String getSaveData() {
		
		String temp = "";
		
		temp = this.getName() + "\n" + this.getStringClass() + "\n" + this.getTotalExp() + "\n" + this.getLevel() + "\n" + this.getCurrentHP();
		
		return temp;
		
	}
	
}
