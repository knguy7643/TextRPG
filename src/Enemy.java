import java.util.concurrent.ThreadLocalRandom;

public class Enemy {

	private EnemyType enemyType;
	private String name;
	private int level;
	private int hp;
	private int agility;
	private int atk;
	private int def;
	private int expValue;
	
	public Enemy(EnemyType enemyType, int level) {
		this.enemyType = enemyType;
		
		this.name = enemyType.toString();
		
		this.level = level;
		
		int[] temp = enemyType.getStats();
		
		this.hp = temp[0] * level;
		
		this.atk = temp[1] * level;
		
		this.def = temp[2] * level;
		
		this.agility = temp[3] * level;
		
		expValue = ThreadLocalRandom.current().nextInt(1, 6);
	}
	
	public int getExp() {
		return  expValue;
	}
	
	public int getAgility() {
		return this.agility;
	}
	
	public int getAttack() {
		return this.atk;
	}
	
	public int getDefense() {
		return this.def;
	}
	
}
