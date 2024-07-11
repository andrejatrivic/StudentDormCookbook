import '../styles/CreateRecipe.css';
import axios from 'axios';
import { useState } from 'react'; // Import useState hook

const CreateRecipe = () => {
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');

    const handleNameChange = (e) => {
        setName(e.target.value);
    };

    const handleDescriptionChange = (e) => {
        setDescription(e.target.value);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        try {
            const response = await axios.post('https://localhost:7118/api/Ingredient/create', {
                name,
                description
            });

            console.log('Ingredient created:', response.data);
        } catch (error) {
            console.error('Error creating ingredient:', error);
        }
        setName('');
        setDescription('');
    };

    return (
        <div className="create-recipe-container">
            <div className="header">
                <h1>Kreiraj recept</h1>
                <h2>Ovdje ide tekst o kreiranju recepta.</h2>
            </div>
            <div className="create-ingredient-form">
            <p>Ako ne vidite sastojak pri kreiranju recepta, prvo ga dodajte kroz ovu formu</p>
                <form onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="name">Naziv:</label>
                        <input
                            type="text"
                            id="name"
                            name="name"
                            value={name}
                            onChange={handleNameChange}
                            required
                        />
                    </div>
                    <div className="form-group">
                        <label htmlFor="description">Opis:</label>
                        <textarea
                            id="description"
                            name="description"
                            value={description}
                            onChange={handleDescriptionChange}
                            required
                        />
                    </div>
                    <button type="submit">Dodaj sastojak</button>
                </form>
            </div>
        </div>
    );
};

export default CreateRecipe;
