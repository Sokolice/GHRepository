import { observer } from "mobx-react-lite";
import { useEffect } from "react";
import { Link, useParams } from "react-router-dom";
import {
  Button,
  Card,
  CardContent,
  CardGroup,
  CardHeader,
  Divider,
  Image,
} from "semantic-ui-react";
import { store } from "../../app/stores/store";
import LoadingComponent from "../layout/LoadingComponent";

const RecipeHints = observer(function RecipeHints() {
  const { name } = useParams();

  useEffect(() => {
    async function fetchData() {
      if (name) {
        await store.recipesStore.loadRecipes(
          name?.substring(0, name.indexOf(" ")),
        );
      }
    }
    fetchData();
  }, [store.recipesStore.loadRecipes]);

  if (store.globalStore.loading) return <LoadingComponent />;
  return (
    <>
      <Button
        icon="pointing left"
        as={Link}
        to={"/plantrecords"}
        content="zpet"
      />
      <Divider hidden />
      {store.recipesStore.recipes.length > 0 ? (
        <CardGroup itemsPerRow={3}>
          {store.recipesStore.recipes.map((item) => {
            return (
              <Card key={item.name}>
                <Image src={item.imageSrc} />
                <CardContent>
                  <CardHeader>{item.name}</CardHeader>
                </CardContent>
                <CardContent extra>
                  <a href={item.url}>{item.url}</a>
                </CardContent>
              </Card>
            );
          })}
        </CardGroup>
      ) : (
        <></>
      )}
    </>
  );
});

export default RecipeHints;
