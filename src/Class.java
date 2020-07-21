
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
			int[] arr= {50, 45, 20, 25};
			return arr;
		}
		else if (this == Class.Braver) {
			int[] arr= {30, 65 , 15, 30};
			return arr;
		}
		else if (this == Class.Swordsman) {
			int[] arr= {50, 20 , 50, 20};
			return arr;
		}
		else if (this == Class.Force) {
			int[] arr= {35, 35, 35, 35};
			return arr;
		}
		else { // Assassin Class
			int[] arr= {25, 51, 22, 42};
			return arr;
		}
		
	}
	
	public int[] levelUpBonus() {
		if (this == Class.Fighter) {
			int[] arr= {5, 4, 2, 2};
			return arr;
		}
		else if (this == Class.Braver) {
			int[] arr= {3, 6 , 2, 3};
			return arr;
		}
		else if (this == Class.Swordsman) {
			int[] arr= {5, 2 , 5, 2};
			return arr;
		}
		else if (this == Class.Force) {
			int[] arr= {3, 4, 3, 4};
			return arr;
		}
		else { // Assassin Class
			int[] arr= {2, 6, 2, 5};
			return arr;
		}
	}
	
}
