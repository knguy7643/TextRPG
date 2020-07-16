
public class Ability {

	private String abilityName;
	private String description;
	private int baseDamage;
	private int manaCost;
	
	public Ability(String abilityName, String description, int baseDamage, int manaCost) {
		this.abilityName = abilityName;
		this.description = description;
		this.baseDamage = baseDamage;
		this.manaCost = manaCost;
	}
	
	public String getAbilityName() {
		return abilityName;
	}
	
	public String getDescription() {
		return description;
	}
	
	public int getBaseDamage() {
		return baseDamage;
	}
	
	public int getManaCost() {
		return manaCost;
	}
	
}
