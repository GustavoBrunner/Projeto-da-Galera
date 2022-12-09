using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using DTO;

    public class PlayerController : PhysicsController
    {
        const int maxHp = 100;
        const int maxStamina = 100;
        public int armor { get ; protected set; }
        public int stamina { get; protected set; } = maxStamina;
            

        public int hp = maxHp;
        public int _hp 
        {
            get
            {
                return hp;
            }
        }
        private float horizontal;
        private float vertical;
        private Vector2 direction;
        private float speed = 5f;

        private float maxSpeed = 5f;
        private float currentSpeed = 0f;
        public AnimationCurve accelerationCurve;
        private float accDuration = 0.5f;
        private int goldqtd;
        public int _goldqtd
        {
            get
            {
                return goldqtd;
            }
        }
        private RangeFloat accTime = new RangeFloat(0,1f); //retona um valor, caso ele esteja entre os dois valores. 
        public float acceleration; //variável criada pra mostrar informação no editor
        public bool hasMove; //variável criada pra mostrar informação no editor
        public bool HasMovement //verifica se o vetor de movimento do player tem tamanho maior que 0
        {
            get
            {
                return direction.magnitude > 0;
            }
        }
        private Vector2 _lastDirection = new Vector2();
        public Vector2 LastDirection //armazena a última direção que o player estava direcionado.
        {
            get
            {
                if(HasMovement)
                {
                    _lastDirection = direction;
                }
                return _lastDirection;
            }
        }
        public float targetSpeed; //variável criada pra mostrar informação no editor
        protected float TargetSpeed
        {
            get 
            {
                if(HasMovement)
                {
                    return maxSpeed;
                }
                else
                {
                    return 0 ;
                }
            }
        }


        private int xp = 0;
        public int _xp 
        {
            get
            {
                return xp;
            }
            protected set
            {
                hp = _xp;
            }
        }
        private int lv = 1;

        const int maxLv = 99;

        [SerializeField]
        private float[] levelsXp = new float[maxLv];

        InputController IC = new InputController();
        protected override void Awake()
        {
            base.Awake();
            
            this.gameObject.tag = "Player";
            for (int i = 1; i < levelsXp.Length; i++)
            {
                float xpController = 5000;
                levelsXp[0] = 1000;
                levelsXp[i] += levelsXp[i-1] + xpController;
                Debug.Log(levelsXp[i]);
            }

        }

        void Update()
        {
            move();
            TakeDamage(20);
            LevelUp();
            Dash();

            if(Input.GetKeyDown(KeyCode.Space))
            {
                XpUp(100);
            }
            
        }

        public void GetData(Player_base data) //passa os dados do DTO de volta para o player
        {
            this.name = data.name;
            this.hp = data.hp;
            GameEvents.OnTakeDamage.Invoke(hp);
            this.speed = data.speed;
            this.goldqtd = data.goldQtd;
            this.armor = data.armor;
            Vector3 loadPos;
            loadPos.x = data.position[0];
            loadPos.y = data.position[1];
            loadPos.z = data.position[2];
            transform.position = loadPos;
            this.stamina = data.stamina;
        }
        private void move()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
            direction = new Vector2(horizontal,vertical);

            if (HasMovement)//vai ou adicionando ou diminuindo na nossa aceleração por meio dos métodos do RangeFloat.
            {
                accTime.add(Time.deltaTime/accDuration);
            }
            else
            {
                accTime.Sub(Time.deltaTime / accDuration);
            }
            acceleration = accTime.Current; //após essa operação, passamos o valor pra uma variável de aceleração, pra ver informação no
            currentSpeed = maxSpeed*accelerationCurve.Evaluate(accTime.Current);//Depois passamos uma multiplicação da velocidade máxima pelo método Evalute da nossa curva de aceleração, passando a variável accTime
            rb.velocity = LastDirection.normalized*currentSpeed; // por último, passamos as informações para o rigidbody
            hasMove = HasMovement;
            targetSpeed = TargetSpeed;

        }

        
        private void Dash()
        {
            if(Input.GetMouseButtonDown(1))
            {
                stamina -=34;
                float ratio = (float)stamina/maxStamina;
                GameEvents.UpdateStamina.Invoke(ratio);
                Debug.Log(stamina);
            }
        }
        //função responsável por tomar dano. Ela subtrai o damage da vida, divide a vida atual pela vida total, e passa razão
        //para o evento.
        private void TakeDamage(int damage)
        {
            if(Input.GetMouseButtonDown(0))
            {
                hp -=damage;
                float ratio = (float)hp / maxHp;
                GameEvents.OnTakeDamage.Invoke(ratio);
            }
        }
        private void XpUp(int EnemieXp)
        {
            this.xp += EnemieXp;
            GameEvents.UpdateXp.Invoke(xp);
        }
        private void LevelUp()
        {
            if(xp >= levelsXp[0] && lv < 2)
            {
                lv += 1;
                GameEvents.OnLevelUp.Invoke(lv);
                return;
            } 
            
            if(xp >= levelsXp[1] && lv < 3)
            {
                lv += 1;
                GameEvents.OnLevelUp.Invoke(lv);
                return;
            }
            
        }
    }
