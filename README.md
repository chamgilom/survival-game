# SURVIVAL GAME 김형진

이 게임은 총을 쏴서 곰을 죽이는게 목적인 게임이다

이 게임은 총 4개의 씬으로 구성되어 있는데 Startscene, mainscene, youlosescene, youwinscene이 있다.
StartScene은 게임 실행 시 가장 먼저 나오는 씬으로 start 버튼을 누르면 mainscene으로 이동한다.

mainscene에서는 본격적인 게임이 시작된다. 플래이어는 총을 가지고 시작하며 화면 좌측 하단에는 플레이어의 체력 바와 현재 가지고 있는 총알, 한번에 장전할 수 있는 총알, 총 가지고 있는 총알의 개수를 나타내는 UI가 배치되어 있다. 화면 상단에는 곰의 체력바를 나타내는 UI가 배치되어 있다.

지형은 water, rock, plant, cloud, lowpolyterrain으로 구성되어 있다. 

곰은 AI Navigation을 사용해서 water를 건너지 못하게 막았고 Idle, Attack, Moving애니메이션을 추가해 주었다. 또한 NPC스크립트를 사용해서 스텟 등을 조절할 수 있게 만들었다.

player는 총을 들고 있는 모습으로 표현하였다. maincamera를 삽입해서 카메라가 플레이어를 따라가게 만들었다. Input system을 사용해서 조작키를 설정하였다. playercondition스크립트에서는 플레이어의 스텟을, guncontroller에서는 총의 상태를, playercontroller에서는 플레이어의 상태를 설정한다.

player에 붙어있는 gun은 마우스 좌클릭을 누르면 발사하고 R을 누르면 재장전을 하도록 만들었다. particle system을 사용해서 총알이 물체에 부딪혔을 때 파편이 튀는 것처럼 설정하였고 audio source를 사용해서 발사시 총소리가 나도록 설정하였다. gun스크립트에서는 총의 스텟을 설정할 수 있다.

내가 게임을 제작하면서 가장 힘들었던 부분은 스크립트 부분이었다. 증상은 한번 공격을 시작했을때 공격상태가 비활성화되지 않고 반복되는 증상이었는데 키 입력을 종료했을 때 설정을 하지 않아서 생기는 문제였다.

아쉽게도 다양한 잡몹의 추가나 스폰에 관한 기능을 넣지 못했다. 나중에라도 꼭 다양한 적을 넣고 일정한 위치에서 스폰할 수 있게 만들 것이다.





총의 모델링은 https://assetstore.unity.com/packages/3d/props/guns/sci-fi-gun-light-87916
총의 사운드는 https://assetstore.unity.com/packages/audio/sound-fx/sci-fi-guns-sfx-pack-181144
곰은 https://assetstore.unity.com/packages/3d/characters/animals/free-stylized-bear-rpg-forest-animal-228910#content
지형은 https://assetstore.unity.com/packages/3d/environments/landscapes/simple-low-poly-nature-pack-157552 에서 구할 수 있었다.
