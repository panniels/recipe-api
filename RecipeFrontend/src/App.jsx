import { Routes, Route } from "react-router-dom";

import DisplayRecipes from "./Pages/DisplayRecipes";
import CreateRecipe from "./Pages/CreateRecipe";
import TopBar from "./Components/TopBar";


function App() {

  return (
    <div>
      <TopBar />

      <Routes>
        <Route path="/" element={<DisplayRecipes />} />
        <Route path="/create-recipe" element={<CreateRecipe />} />
      </Routes>
      
    </div>
  );
}

export default App;