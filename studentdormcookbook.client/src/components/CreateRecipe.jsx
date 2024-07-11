import '../styles/CreateRecipe.css';
import axios from 'axios';
import { useState } from 'react';

const CreateRecipe = () => {
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [message, setMessage] = useState('');
    const [error, setError] = useState('');

    const handleNameChange = (e) => {
        setName(e.target.value);
    };

    const handleDescriptionChange = (e) => {
        setDescription(e.target.value);
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        setMessage('');
        setError('');

        try {
            const response = await axios.post('https://localhost:7118/api/Ingredient/create', {
                name,
                description
            });

            setMessage('Uspješno kreiran sastojak!');
            console.log('Sastojak kreiran:', response.data);
        } catch (error) {
            setError('Greška kod kreiranja sastojka. Pokušajte ponovo.');
            console.error('Greška kod kreiranja sastojka:', error);
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
                        <input
                            type="text"
                            id="description"
                            name="description"
                            value={description}
                            onChange={handleDescriptionChange}
                            required
                        />
                    </div>
                    <button type="submit">Dodaj sastojak</button>
                </form>
                {message && <p className="success-message">{message}</p>}
                {error && <p className="error-message">{error}</p>}
            </div>
        </div>
    );
};

export default CreateRecipe;
