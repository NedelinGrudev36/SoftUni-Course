function solve(input){
    let numberHeroes = Number(input[0]);
    let teamInfo = input.slice(1, numberHeroes + 1);
    let commands = input.slice(numberHeroes + 1);

    let heroesTeam = teamInfo.reduce((acc,curr) => {
        const[name,hp,bullets] = curr.split(' ');
        acc[name] = {hp, bullets}
        return acc;
    }, {});


    for (const cmd of commands) {
        let command = cmd.split(' - ');
        let [mainCmd, cmdInfo] = [command[0], command.slice(1)];

        switch(mainCmd){
            case 'FireShot':
                const [characterName, target] = cmdInfo;

                if(heroesTeam[characterName].bullets > 0){
                    heroesTeam[characterName].bullets -= 1;
                    console.log(`${characterName} has successfully hit ${target} and now has ${heroesTeam[characterName].bullets} bullets!`);
                }
                else{
                    console.log(`${characterName} doesn't have enough bullets to shoot at ${target}!`);
                }
                break;
            case 'TakeHit':
                let [name, damage, attacker] = cmdInfo;
                damage = Number(damage);
                heroesTeam[name].hp -= damage;

                if(heroesTeam[name].hp > 0){
                    console.log(`${name} took a hit for ${damage} HP from ${attacker} and now has ${heroesTeam[name].hp} HP!`);
                }
                else{
                    console.log(`${name} was gunned down by ${attacker}!`);
                    delete heroesTeam[name];
                }
                break;
            case 'Reload':
                const character = cmdInfo;
                if(heroesTeam[character].bullets < 6){
                    let bulletsReloaded = 6 - heroesTeam[character].bullets;
                    console.log(`${character} reloaded ${bulletsReloaded} bullets!`);
                    heroesTeam[character].bullets = 6;
                }
                else if(heroesTeam[character].bullets === 6){
                    console.log(`${character}'s pistol is fully loaded!`);
                }
                break;
            case 'PatchUp':
                let [charactername, amount] = cmdInfo;
                amount = Number(amount);

                if(heroesTeam[charactername].hp === 100){
                    console.log(`${charactername} is in full health!`);
                } else if (heroesTeam[charactername].hp + amount > 100){
                    console.log(`${charactername} patched up and recovered ${100 - heroesTeam[charactername].hp} HP!`);
                    heroesTeam[charactername].hp = 100;
                } else{
                    console.log(`${charactername} patched up and recovered ${amount} HP!`);
                    heroesTeam[charactername].hp += amount;
                }
                break;
            case 'Ride Off Into Sunset':
                break;
        }
    }

    for (const [name,info] of Object.entries(heroesTeam)) {
        console.log(name);
        console.log(` HP: ${info.hp}`);
        console.log(` Bullets: ${info.bullets}`);
    }
}

