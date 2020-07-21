
public enum Class {

	Fighter, Braver, Swordsman, Force, Assassin;
	
	/*
	 * Force - Starts all fights with an extra mana.
	 * Fighter - Higher HP and Attack.
	 * Braver - Highest Attack but lower Defense.
	 * Swordsman - Higher HP and Defense.
	 * Assassin - Higher Atk and Agility.
	 */
	
	public int[] getStats() {
		
		if (this == Class.Fighter) {
			int[] arr= {0, 0 , 0, 0};
			return arr;
		}
		else if (this == Class.Braver) {
			int[] arr= {0, 0 , 0, 0};
			return arr;
		}
		else if (this == Class.Swordsman) {
			int[] arr= {0, 0 , 0, 0};
			return arr;
		}
		else if (this == Class.Force) {
			int[] arr= {0, 0 , 0, 0};
			return arr;
		}
		else {
			int[] arr= {0, 0 , 0, 0};
			return arr;
		}
		
	}
	
	public int[] levelUpBonus() {
		return null;
	}
	
}
