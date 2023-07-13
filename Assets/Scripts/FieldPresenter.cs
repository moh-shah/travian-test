using TravianTest.Snake.Logic;
using UnityEngine;

namespace TravianTest.Snake.Presenters
{
    public class FieldPresenter : MonoBehaviour
    {
        [SerializeField] private GameObject wallObject;

        private IFieldLogic _fieldLogic;

        // Start is called before the first frame update
        void Start()
        {
            _fieldLogic = DependencyManager.Instance.fieldLogic;
            InitiateField();
            Instantiate(DependencyManager.Instance.gameConfig.snakeHeadPresenterPrefab, Vector3.zero, Quaternion.identity);
        }

        private void InitiateField()
        {
            var halfOfTheWidth = _fieldLogic.FieldWidth() / 2f;
            var halfOfTheHeight = _fieldLogic.FieldHeight() / 2f;
            var halfOfTheScale = wallObject.transform.localScale.x / 2f;
            for (var x = 0; x < _fieldLogic.FieldWidth(); x++)
            {
                for (var y = 0; y < _fieldLogic.FieldHeight(); y++)
                {
                    if (x == 0 || x == _fieldLogic.FieldWidth() - 1)
                        Instantiate(wallObject,
                            new Vector3(x - halfOfTheWidth + halfOfTheScale, y - halfOfTheHeight + halfOfTheScale),
                            Quaternion.identity, transform);

                    if (y == 0 || y == _fieldLogic.FieldHeight() - 1)
                        Instantiate(wallObject,
                            new Vector3(x - halfOfTheWidth + halfOfTheScale, y - halfOfTheHeight + halfOfTheScale),
                            Quaternion.identity, transform);
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}