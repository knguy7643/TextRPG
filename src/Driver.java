import java.awt.BorderLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;
import javax.swing.JTextField;
import javax.swing.text.DefaultCaret;

public class Driver {
	
	private static String playerName;
	private static Class playerClass;
	private static Player player = new Player("", Class.None);
	private static String offset = "\n\n";
	
	public static void main(String[] args) {
	
		//Initialize GUI Here When Ready
		JFrame frame = new JFrame("Xevoria - Simple Text RPG");
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		//Keep size consistent. Change dimensions if needed.
		frame.setResizable(false);
		frame.setSize(700, 400);
		
		//Area to publish text.
		JTextArea system = new JTextArea();
		system.setEditable(false);
		system.setLineWrap(true);
		system.setWrapStyleWord(true);
		
		//Auto scroll on the text area.
		JScrollPane vertical = new JScrollPane(system);
		vertical.setVerticalScrollBarPolicy(JScrollPane.VERTICAL_SCROLLBAR_ALWAYS);
		system.setCaretPosition(system.getDocument().getLength());
		DefaultCaret caret = (DefaultCaret) system.getCaret();
		caret.setUpdatePolicy(DefaultCaret.OUT_BOTTOM);
		
		//Select New File or Saved File
		JPanel fileChoice = new JPanel();
		JButton newFile = new JButton("New Game");
		JButton savedFile = new JButton("Saved File");
		
		fileChoice.add(newFile);
		fileChoice.add(savedFile);
		
		//File Action Listener
		//TODO: Add the action listeners and think about the structure
		
		//Text box for player name.
		JPanel nameFieldPanel = new JPanel();
		JLabel nameFieldLabel = new JLabel("Enter Name (Max 20 characters): ");
		JTextField nameTextField = new JTextField(20);
		JButton nameSubmit = new JButton("Submit");
		JButton nameReset = new JButton("Reset");
		
		nameFieldPanel.add(nameTextField);
		nameFieldPanel.add(nameFieldLabel);
		nameFieldPanel.add(nameSubmit);
		nameFieldPanel.add(nameReset);
		
		//Combo box for Class options.
		JPanel chooseClassPanel = new JPanel();
		JLabel chooseClassLabel = new JLabel("Please select your desired class: ");
		
		String[] classOpts = {"Fighter", "Braver", "Swordsman", "Force", "Assassin"};
		JComboBox<String> classOptions = new JComboBox<>(classOpts);
		
		JButton selectClassButton = new JButton("Submit");
		
		chooseClassPanel.add(chooseClassLabel);
		chooseClassPanel.add(classOptions);
		chooseClassPanel.add(selectClassButton);
		
		selectClassButton.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				if (classOptions.getSelectedItem() == "Fighter") {
					playerClass = Class.Fighter;
				}
				else if (classOptions.getSelectedItem() == "Braver") {
					playerClass = Class.Braver;
				}
				else if (classOptions.getSelectedItem() == "Swordsman") {
					playerClass = Class.Swordsman;
				}
				else if (classOptions.getSelectedItem() == "Force") {
					playerClass = Class.Force;
				}
				else {
					playerClass = Class.Assassin;
				}
				
				//Create the player object.
				player = new Player(playerName, playerClass);
				
			}
		}));
		
		//Panel to display player stats.
		JPanel playerStats = new JPanel();
		JLabel playerNameLabel = new JLabel("Player Name: " + player.getName());
		JLabel playerClassLabel = new JLabel("Class: " + player.getClass().toString());
		JLabel playerLvlLabel = new JLabel("Player Level: " + player.getLvl());
		JLabel playerExp = new JLabel("EXP Needed to Level: " + player.expNeeded());
		JLabel playerHP = new JLabel("HP: " + player.getHP() + "/" + player.getMaxHP());
		JLabel playerMana = new JLabel("Mana: "+ player.getMana());
		JLabel playerAtk = new JLabel("Attack: " + player.getAttack());
		JLabel playerDef = new JLabel("Defense: " + player.getDefense());
		
		playerStats.setLayout(new GridLayout(8, 1));
		
		playerStats.add(playerNameLabel);
		playerStats.add(playerClassLabel);
		playerStats.add(playerLvlLabel);
		playerStats.add(playerExp);
		playerStats.add(playerHP);
		playerStats.add(playerMana);
		playerStats.add(playerAtk);
		playerStats.add(playerDef);

		//Add components to frame
		frame.add(BorderLayout.CENTER, vertical);
		frame.add(BorderLayout.SOUTH, fileChoice);
		frame.add(BorderLayout.WEST, playerStats);
		
		//Set frame visible
		frame.setVisible(true);
		
		system.append("Welcome to Xevoria. Will you conquer this realm or perish under its trials?");
		
		newFile.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				
				frame.remove(fileChoice);
				
				system.append("As your visions comes into focus, you find youself standing on the pier with a large barquentine sitting in the water in front of you. You see upon its three giant masts, brimming white"
						+ " sails waving by the smooth gently sea breeze. Up top the main mast, you see the flag of the Xevorian Council, waving with its majestic blue and gold colors. You feel a slight tap on your"
						+ " shoulder. You turn to a short elderly man standing beside you, and he asks \"Excuse me young man. Would you mind helping this old man board the ship?\"" + offset);
			
				system.append("\"Board. Board the ship.\" You hear ghastly whispering in your ear. You decided to help him board the ship." + offset);
				
				frame.add(BorderLayout.SOUTH, nameFieldPanel);
				
				system.append("You are standing upon the top deck of the ship, staring off to the horizon, seemingly lost in thought. \"You seem quite aloof. Must be all these beautiful women occupying your mind,\""
						+ " you hear from a familiar sounding voice. It is the old man you helped board the ship. \"Allow me to preperly introduce myself, I am Roshi. What is your name?\"" + offset);
				
				frame.revalidate();
				
			}
		}));
		
		//Come back to this.
		savedFile.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				system.append("");
			}
		}));
		
		//Submit and Reset Action Listeners for player name.
		nameSubmit.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				playerName = nameTextField.getText();
						
				frame.remove(nameFieldPanel); 
						
				frame.add(BorderLayout.SOUTH, chooseClassPanel);
						
				frame.revalidate();
				
				system.append("You have selected " + playerName + "as you name." + offset);
				
				system.append("\"A wonderful name,\" Roshi replies. \"Land Ho!\" A ship crew shouts, as Xevoria draws over the horizon towards you and Roshi. \"Why are you heading to Xevoria young man?\" Roshi asks "
						+ "You explain how suddenly woke up on the small island nation with no one around and no memories besides your name. You moved from job to job until a few days ago. Something was calling you to board "
						+ "the ship so you did. Roshi is quite intrigued and decides to tell about Xevoria." + offset);
				
				system.append("");
				
			}
		}));
				
		nameReset.addActionListener((new ActionListener() {
			public void actionPerformed(ActionEvent e) {
				nameTextField.setText("");
			}
		}));
		
	}
	
	//Come back to this. 
	public static void tutorial(JTextArea system) {
		
	}
	
	public static void battle(JTextArea system, Player player, Enemy enemy) {
		//Work on parameters.
		
		if (player.getAgility() >= enemy.getAgility()) {
			while ((player.getHP() != 0) || (enemy.getHP() != 0)) {
				
			}
			if (player.getHP() == 0) {
				//System "You have die."
			}
			else {
				//System "You have slain..."
				//Gain exp
			}
		}
		else {
			
		}
		
	}
	
}
