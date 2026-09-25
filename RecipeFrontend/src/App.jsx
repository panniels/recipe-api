import { useState, useEffect } from "react";


function App() {
const [recipes, setRecipes] = useState([]);

useEffect(() => {
  fetch("http://localhost:5244/api/recipe")
    .then((response) => response.json())
    .then((data) => setRecipes(data));
}, []);

  return (
    <div>
      <h1>Recipes</h1>

      <ul>
        {recipes.map((recipe) => (
          <li key={recipe.id}>
            {recipe.name} - {recipe.cookingTime} minutes
          </li>
        ))}
      </ul>
    </div>
  );
}

export default App;