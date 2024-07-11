import React from 'react';
import { BrowserRouter as Router, Route, Routes, Link } from 'react-router-dom';
import './styles/App.css';
import Salty from './components/Salty';
import Sweet from './components/Sweet';
import Drinks from './components/Drinks';
import CreateRecipe from './components/CreateRecipe';
import About from './components/About';

const App = () => {
    return (
        <Router>
            <div className="app-container">
                <div className="header-and-icon">
                    <div className="header">
                        <h1>Studentska kuharica</h1>
                        <h2>Brzi obroci za studentski džep i apetit.</h2>
                    </div>
                    <div className="icon">
                        <span className="icon-fork-spoon">&#x1F37D;</span>
                    </div>
                </div>
                <div className="menu">
                    <Link to="/slano">
                        <button className="menu-button">Slano</button>
                    </Link>
                    <Link to="/slatko">
                        <button className="menu-button">Slatko</button>
                    </Link>
                    <Link to="/pica">
                        <button className="menu-button">Pića</button>
                    </Link>
                    <Link to="/kreiraj">
                        <button className="menu-button">Kreiraj recept</button>
                    </Link>
                    <Link to="/autor">
                        <button className="menu-button">O autoru</button>
                    </Link>
                </div>

                <Routes>
                    <Route path="/slano" element={<Salty />} />
                    <Route path="/slatko" element={<Sweet />} />
                    <Route path="/pica" element={<Drinks />} />
                    <Route path="/kreiraj" element={<CreateRecipe />} />
                    <Route path="/autor" element={<About />} />
                </Routes>
            </div>
        </Router>
    );
};

export default App;
