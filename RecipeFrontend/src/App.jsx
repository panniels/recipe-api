import { useState, useEffect } from "react";


function App() {
const [recipes, setRecipes] = useState([]);

useEffect(() => {
  fetch("http://localhost:5244/api/recipe")
    .then((response) => response.json())
    .then((data) => { console.log("Data: ", data); setRecipes(data)})
    .catch((error) => { console.error("Error: ", error) });
}, []);

  return (
    <div>
      <h1>Recipes</h1>

      <ul>
        {recipes.map((recipe) => (
          <li key={recipe.id}>
            <div>{recipe.name} - {recipe.cookingTime} minutes</div>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;