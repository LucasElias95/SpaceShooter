using UnityEngine;

public class MeteorController : MonoBehaviour
{
    [SerializeField]
    private MeteorsConfig[] meteorsConfig;
    private float timeSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.timeSpawn = 0; //valor inicia em zero
    }

    // Update is called once per frame
    void Update()
    {
        //criar um novo inimigo toda vez que o tempo for maior ou igual a que 1
        this.timeSpawn += Time.deltaTime; // a cada frame o valor é acrescido em +1
        if (this.timeSpawn >= 5f)
        {
            this.timeSpawn = 0; // retorna o tempo a 0

            
            float chance = Random.Range(0f, 100f);
            Debug.Log("Chance: " + chance);     
            if (chance >= 30f)
            {  
                Spawn();
            }    
            

        }
        
    }
    public void Spawn()
        {
            Vector2 maxPosition = Camera.main.ViewportToWorldPoint(new Vector2(1, 2)); //define os valores maximos dos eixos x e y do cenario
            Vector2 minPosition = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //define os valores minimos dos eixos x e y do cenario

            float positionX = Random.Range(minPosition.x, maxPosition.x); //instancia um inimigo no eixo x dentro dos limites definidos
            Vector2 meteorPosition = new Vector2(positionX, maxPosition.y); //instancia um inimigo no eixo y dentro dos limites definidos

            //define a porcentagem de chance de cada inimigo ser instanciado
            /*float chance = Random.Range(0f, 100f);
            if (chance <= 60)
            {
                prefabMeteor = this.meteor1;
            }
            else
            {
                prefabMeteor = this.meteor2;
            }*/

            //instancia o inimigo
            MeteorsConfig meteorsConfig = GetConfigRandomMeteor();
            Meteor prefabMeteor = meteorsConfig.MeteorPrefab;
            //instancia o inimigo
            Meteor newMeteor = Instantiate(prefabMeteor, meteorPosition, Quaternion.identity);
            newMeteor.Config(meteorsConfig.MeteorProperties);
            }

    private MeteorsConfig GetConfigRandomMeteor()
    {
        if((this.meteorsConfig == null) || (this.meteorsConfig.Length == 0))
        {
            return null;
        }
        int randomIndice = Random.Range(0, this.meteorsConfig.Length);
        return this.meteorsConfig[randomIndice];
    }
}
