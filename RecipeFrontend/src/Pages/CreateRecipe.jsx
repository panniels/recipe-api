
function CreateRecipe() {
    const formData = new FormData();
    formData.append("file", selectedFile);

    fetch(`http://localhost:5244/api/recipe/${recipeId}/image`, {
        method: "POST",
        body: formData,
    });
    return (
        <div>
            <h1>Create Recipe Page</h1>
            {/* Add your form or content for creating a recipe here */}
        </div>
    );
}
export default CreateRecipe;