# 🏠 Real Estate Agent - Asistente Inmobiliario Inteligente

[![Python](https://img.shields.io/badge/Python-3.8+-blue.svg)](https://www.python.org/)
[![LangChain](https://img.shields.io/badge/LangChain-0.3.7-green.svg)](https://www.langchain.com/)
[![Google Colab](https://img.shields.io/badge/Google%20Colab-F9AB00?style=flat&logo=google-colab&logoColor=white)](https://colab.research.google.com/)

**Desarrollado por Lucas Tejería**

Un agente conversacional inteligente basado en IA que proporciona asesoramiento integral para la venta de propiedades inmobiliarias. El sistema combina Machine Learning para predicción de precios, RAG (Retrieval Augmented Generation) para consultas sobre documentación especializada, y una interfaz web interactiva.

**Este proyecto está diseñado para ejecutarse en Google Colab mediante notebooks de Jupyter.**

---

# 🇪🇸 Español

## 📋 Tabla de Contenidos

- [Descripción](#descripción)
- [Características Principales](#características-principales)
- [Arquitectura y Tecnologías](#arquitectura-y-tecnologías)
- [Notebooks del Proyecto](#notebooks-del-proyecto)
- [Configuración y Requisitos](#configuración-y-requisitos)
- [Cómo Usar el Proyecto](#cómo-usar-el-proyecto)
- [Estructura del Proyecto](#estructura-del-proyecto)
- [Resultados y Métricas](#resultados-y-métricas)
- [Mejoras Futuras](#mejoras-futuras)

## 🎯 Descripción

**Real Estate Agent** es un sistema de asesoramiento inmobiliario que integra tres capacidades principales:

1. **Predicción de Precios**: Modelo de Machine Learning entrenado con datos reales del mercado inmobiliario de Montevideo (2018) que estima el precio de venta recomendado basado en características de la propiedad.

2. **Recomendaciones de Mantenimiento**: Sistema RAG que consulta documentación oficial del Ministerio de Vivienda y Ordenamiento Territorial para responder preguntas sobre el buen uso y mantenimiento de viviendas.

3. **Errores Comunes al Vender**: Base de conocimiento especializada que identifica y explica errores frecuentes durante el proceso de venta de propiedades.

El agente utiliza **LangGraph** para orquestar conversaciones inteligentes, seleccionando automáticamente las herramientas apropiadas según el contexto de la consulta del usuario.

## ✨ Características Principales

- 🤖 **Agente Conversacional Inteligente**: Interfaz de chat natural que entiende el contexto y selecciona automáticamente las herramientas adecuadas
- 📊 **Predicción de Precios con ML**: Modelo `HistGradientBoostingRegressor` entrenado con datos reales del mercado
- 📚 **RAG (Retrieval Augmented Generation)**: Búsqueda semántica sobre documentación especializada usando embeddings y bases de datos vectoriales
- 🌐 **Interfaz Web Moderna**: Aplicación Gradio integrada en el notebook con chat conversacional y formulario de estimación de precios
- 🔄 **Arquitectura Modular**: Sistema extensible con herramientas independientes y fácilmente configurables
- 📈 **Rendimiento Optimizado**: Modelo con 64% mejor rendimiento que la mediana de referencia

## 🏗️ Arquitectura y Tecnologías

### Stack Tecnológico

**Machine Learning & Data Science:**

- `scikit-learn` (1.6.1) - Modelo HistGradientBoostingRegressor
- `pandas` (2.2.2) - Procesamiento de datos
- `numpy` (1.26.4) - Operaciones numéricas
- `joblib` (1.5.3) - Serialización del modelo

**IA y LLM:**

- `langchain` (0.3.7) - Framework para aplicaciones LLM
- `langgraph` (0.2.19) - Construcción de agentes con grafos de estado
- `langchain-huggingface` (0.1.2) - Integración con modelos HuggingFace
- `sentence-transformers` (5.2.0) - Embeddings semánticos (all-MiniLM-L6-v2)
- `HuggingFace Qwen3-4B-Instruct` - Modelo LLM para generación de respuestas

**Bases de Datos Vectoriales:**

- `pinecone-client` (5.0.1) - Base de datos vectorial para RAG
- `langchain-pinecone` (0.2.0) - Integración LangChain-Pinecone

**Interfaz:**

- `gradio` (6.2.0) - Interfaz web interactiva
- `pypdf` - Procesamiento de documentos PDF

### Arquitectura del Sistema

```
┌─────────────────────────────────────────────────────────┐
│                    Interfaz Gradio                      │
│         (Chat Conversacional + Formulario)              │
│              (Integrada en Agente.ipynb)                │
└──────────────────────┬──────────────────────────────────┘
                       │
                       ▼
┌─────────────────────────────────────────────────────────┐
│                  LangGraph Agent                         │
│              (State Graph Orchestration)                 │
└──────┬──────────────┬──────────────┬────────────────────┘
       │              │              │
       ▼              ▼              ▼
┌─────────────┐ ┌─────────────┐ ┌──────────────────────┐
│   Tool 1:   │ │   Tool 2:   │ │    Tool 3:           │
│ Mantenimiento│ │   Errores   │ │ Predicción Precios   │
│   (RAG)     │ │    (RAG)     │ │      (ML)            │
└──────┬──────┘ └──────┬───────┘ └──────────┬───────────┘
       │               │                    │
       ▼               ▼                    ▼
┌─────────────┐ ┌─────────────┐ ┌──────────────────────┐
│  Pinecone   │ │  Pinecone   │ │  Modelo ML (pickle)  │
│  Index 1    │ │  Index 2    │ │  HistGradientBoost   │
└─────────────┘ └─────────────┘ └──────────────────────┘
```

## 📓 Notebooks del Proyecto

El proyecto consta de **dos notebooks principales** que deben ejecutarse en orden:

### 1. `entrenamiento/entrenamiento_del_modelo.ipynb`

**Propósito**: Entrenar el modelo de Machine Learning para predecir precios de propiedades.

**Funcionalidades**:

- Análisis exploratorio de datos (EDA)
- Limpieza y transformación de datos
- Transformación logarítmica del precio objetivo
- One-Hot Encoding para variables categóricas
- Selección de modelo mediante Grid Search
- Entrenamiento del modelo `HistGradientBoostingRegressor`
- Exportación del modelo entrenado como `modelo_inmobiliario.pkl`

**Input**: Dataset `data_de_entrenamiento/meli_limpio.Rdata` (datos de 2018)

- Dataset original: [Real Estate Offers in Montevideo, Uruguay](https://www.kaggle.com/datasets/ppicardo/real-estate-offers-in-montevideo-uruguay) en Kaggle

**Output**: `modelo_de_prediccion/modelo_inmobiliario.pkl`

### 2. `agente/Agente.ipynb`

**Propósito**: Crear y ejecutar el agente conversacional con todas sus capacidades.

**Funcionalidades**:

- Carga del modelo ML entrenado
- Procesamiento y chunking de documentos PDF
- Generación de embeddings y carga en Pinecone
- Configuración del agente LangGraph con tres herramientas:
  - `recomendacion_buen_uso_vivienda`: Consulta sobre mantenimiento
  - `errores_al_vender_propiedad`: Consulta sobre errores comunes
  - `predecir_precio_venta_propiedad`: Predicción de precios
- Interfaz Gradio integrada para interactuar con el agente

**Inputs**:

- `modelo_de_prediccion/modelo_inmobiliario.pkl` (generado por el notebook de entrenamiento)
- `documentos/guia para el buen uso de la vivienda_para web.pdf`
- `documentos/erroresAlVenderTuPropiedad.pdf`

**Output**: Interfaz web interactiva con el agente

## ⚙️ Configuración y Requisitos

### Requisitos Previos

- Cuenta de Google (para usar Google Colab)
- Cuenta en [Pinecone](https://www.pinecone.io/) (plan gratuito disponible)
- Token de [HuggingFace](https://huggingface.co/) (gratuito)

### Configuración de Variables de Entorno

Ambos notebooks requieren configurar las siguientes variables de entorno en las celdas correspondientes:

```python
import os

# Pinecone API Key (obtener en https://www.pinecone.io/)
os.environ["PINECONE_API_KEY"] = "tu-api-key-aqui"

# HuggingFace Token (obtener en https://huggingface.co/settings/tokens)
os.environ["HF_TOKEN"] = "tu-token-aqui"
```

### Configuración de Pinecone

1. Crear una cuenta en [Pinecone](https://www.pinecone.io/)
2. Crear dos índices vectoriales:
   - **Índice 1**: `guia-mantenimiento`
     - Dimensiones: 384
     - Métrica: cosine
   - **Índice 2**: `errores-venta-propiedad`
     - Dimensiones: 384
     - Métrica: cosine

**Nota**: Los índices se crean automáticamente en el notebook `Agente.ipynb` si no existen, o puedes crearlos manualmente desde el dashboard de Pinecone.

## 💻 Cómo Usar el Proyecto

### Flujo de Trabajo Completo

#### Paso 1: Entrenar el Modelo

1. Abrir `entrenamiento/entrenamiento_del_modelo.ipynb` en Google Colab
2. Subir el archivo `data_de_entrenamiento/meli_limpio.Rdata` al entorno de Colab
3. Ejecutar todas las celdas del notebook
4. El notebook generará `modelo_inmobiliario.pkl` que debe descargarse y guardarse

#### Paso 2: Configurar y Ejecutar el Agente

1. Abrir `agente/Agente.ipynb` en Google Colab
2. Subir los siguientes archivos a la raíz del proyecto en Colab:
   - `modelo_de_prediccion/modelo_inmobiliario.pkl` (generado en el Paso 1)
   - `documentos/guia para el buen uso de la vivienda_para web.pdf`
   - `documentos/erroresAlVenderTuPropiedad.pdf`
3. Configurar las variables de entorno (PINECONE_API_KEY y HF_TOKEN) en las celdas correspondientes
4. Ejecutar todas las celdas del notebook
5. El notebook cargará los documentos en Pinecone (si es la primera vez) y luego iniciará la interfaz Gradio

### Uso del Agente

Una vez ejecutado el notebook `Agente.ipynb`, tendrás acceso a una interfaz Gradio con dos modos:

#### Modo Chat Conversacional

Puedes hacer preguntas en lenguaje natural como:

- "Quiero vender mi apartamento en Pocitos, ¿qué errores debería evitar?"
- "¿Cómo mantengo en buen estado una casa antigua?"
- "Tengo una casa en La Teja, 2 dormitorios y 1 baño, ¿qué precio puede tener?"

El agente seleccionará automáticamente la herramienta apropiada según tu consulta.

#### Modo Formulario de Estimación

Puedes completar un formulario con las características de tu propiedad para obtener una estimación de precio directamente del modelo ML.

### Parámetros del Modelo de Predicción

El modelo acepta las siguientes características para predecir el precio:

**Características Obligatorias:**

- `tipoInmueble`: "Apartamentos" o "Casas"
- `barrio`: Nombre del barrio en Montevideo
- `condicion`: "new" o "used"
- `departamento`: "Montevideo"

**Características Opcionales:**

- `dormitorios`: Número de dormitorios (0-6)
- `banos`: Número de baños (0-4)
- `supTot`: Superficie total en m²
- `supConstru`: Superficie construida en m²
- `antiguedad`: Años de antigüedad
- `ambientes`: Número de ambientes
- `expensas`: Monto de expensas
- `apPpiso`: Apartamento por piso
- `ascensores`: Número de ascensores

**Características Booleanas** (Si/No):

- `terraza`, `patio`, `toilette`, `aircond`, `calefacc`, `jardin`, `piscina`, `garage`, `kitchenette`, `losaRad`, `parrillero`, `salaReuniones`, `seguridad`, `amoblado`, `comedor`

**Características Categóricas:**

- `tipoEdif`: Tipo de edificio
- `estado`: "A reciclar", "Regular", "Bueno", "Muy bueno", "Excelente"
- `orientacion`: "Frente", "Contrafrente", "Lateral"

## 📁 Estructura del Proyecto

```
real-estate-agent/
│
├── agente/
│   └── Agente.ipynb                    # Notebook principal del agente (Colab)
│
├── entrenamiento/
│   └── entrenamiento_del_modelo.ipynb # Notebook para entrenar el modelo ML
│
├── modelo_de_prediccion/
│   └── modelo_inmobiliario.pkl        # Modelo entrenado (generado por entrenamiento_del_modelo.ipynb)
│
├── documentos/
│   ├── guia para el buen uso de la vivienda_para web.pdf
│   └── erroresAlVenderTuPropiedad.pdf
│
├── data_de_entrenamiento/
│   └── meli_limpio.Rdata               # Dataset de entrenamiento (2018)
│
├── README.md                            # Este archivo
```

## 📊 Resultados y Métricas

### Rendimiento del Modelo de Predicción

- **Métrica de Rendimiento**: 64% mejor que la mediana de referencia
- **Algoritmo**: HistGradientBoostingRegressor
- **Dataset de Entrenamiento**: Datos del mercado inmobiliario de Montevideo (2018)
- **Transformaciones Aplicadas**:
  - Transformación logarítmica sobre el precio objetivo
  - One-Hot Encoding para variables categóricas
  - Normalización de variables numéricas
- **Optimización**: Grid Search para selección de hiperparámetros

### Capacidades del Agente

✅ **Respuestas Contextuales**: El agente mantiene contexto de la conversación  
✅ **Selección Inteligente de Herramientas**: Identifica automáticamente qué herramienta usar según la consulta  
✅ **Prevención de Alucinaciones**: Solo responde basándose en información verificada  
✅ **Búsqueda Semántica**: Encuentra información relevante incluso con consultas en lenguaje natural

### Limitaciones Conocidas

⚠️ **Datos de 2018**: Los precios predichos corresponden al mercado de 2018 y pueden no reflejar valores actuales  
⚠️ **Cobertura Geográfica**: El modelo está entrenado específicamente para Montevideo, Uruguay  
⚠️ **Calidad de Datos**: El dataset original contenía datos duplicados e inconsistentes que afectan la precisión  
⚠️ **Ejecución en Colab**: El proyecto está diseñado para ejecutarse en Google Colab, no como aplicación standalone

## 🔮 Mejoras Futuras

### Corto Plazo

- [ ] Actualizar el modelo con datos más recientes del mercado inmobiliario
- [ ] Implementar sistema de caché para respuestas frecuentes
- [ ] Agregar validación de entrada más robusta

### Consideraciones Técnicas

- Mejorar la calidad y limpieza del dataset de entrenamiento
- Explorar arquitecturas de modelos más avanzadas (XGBoost, LightGBM, Neural Networks)
- Implementar sistema de A/B testing para diferentes modelos
- Optimizar costos de infraestructura (Pinecone, HuggingFace)

---

# 🇬🇧 English

## 📋 Table of Contents

- [Description](#description)
- [Key Features](#key-features)
- [Architecture and Technologies](#architecture-and-technologies)
- [Project Notebooks](#project-notebooks)
- [Configuration and Requirements](#configuration-and-requirements)
- [How to Use the Project](#how-to-use-the-project)
- [Project Structure](#project-structure)
- [Results and Metrics](#results-and-metrics)
- [Future Improvements](#future-improvements)

## 🎯 Description

**Real Estate Agent** is an intelligent real estate advisory system that integrates three main capabilities:

1. **Price Prediction**: Machine Learning model trained on real estate market data from Montevideo (2018) that estimates the recommended sale price based on property characteristics.

2. **Maintenance Recommendations**: RAG system that queries official documentation from the Ministry of Housing and Territorial Planning to answer questions about proper use and maintenance of homes.

3. **Common Selling Mistakes**: Specialized knowledge base that identifies and explains frequent errors during the property selling process.

The agent uses **LangGraph** to orchestrate intelligent conversations, automatically selecting the appropriate tools based on the user's query context.

**This project is designed to run on Google Colab using Jupyter notebooks.**

## ✨ Key Features

- 🤖 **Intelligent Conversational Agent**: Natural chat interface that understands context and automatically selects appropriate tools
- 📊 **ML Price Prediction**: `HistGradientBoostingRegressor` model trained on real market data
- 📚 **RAG (Retrieval Augmented Generation)**: Semantic search over specialized documentation using embeddings and vector databases
- 🌐 **Modern Web Interface**: Gradio application integrated in the notebook with conversational chat and price estimation form
- 🔄 **Modular Architecture**: Extensible system with independent and easily configurable tools
- 📈 **Optimized Performance**: Model with 64% better performance than the reference median

## 🏗️ Architecture and Technologies

### Technology Stack

**Machine Learning & Data Science:**

- `scikit-learn` (1.6.1) - HistGradientBoostingRegressor model
- `pandas` (2.2.2) - Data processing
- `numpy` (1.26.4) - Numerical operations
- `joblib` (1.5.3) - Model serialization

**AI and LLM:**

- `langchain` (0.3.7) - Framework for LLM applications
- `langgraph` (0.2.19) - Agent construction with state graphs
- `langchain-huggingface` (0.1.2) - HuggingFace model integration
- `sentence-transformers` (5.2.0) - Semantic embeddings (all-MiniLM-L6-v2)
- `HuggingFace Qwen3-4B-Instruct` - LLM model for response generation

**Vector Databases:**

- `pinecone-client` (5.0.1) - Vector database for RAG
- `langchain-pinecone` (0.2.0) - LangChain-Pinecone integration

**Interface:**

- `gradio` (6.2.0) - Interactive web interface
- `pypdf` - PDF document processing

### System Architecture

```
┌─────────────────────────────────────────────────────────┐
│                    Gradio Interface                      │
│         (Conversational Chat + Form)                     │
│              (Integrated in Agente.ipynb)               │
└──────────────────────┬──────────────────────────────────┘
                       │
                       ▼
┌─────────────────────────────────────────────────────────┐
│                  LangGraph Agent                         │
│              (State Graph Orchestration)                 │
└──────┬──────────────┬──────────────┬────────────────────┘
       │              │              │
       ▼              ▼              ▼
┌─────────────┐ ┌─────────────┐ ┌──────────────────────┐
│   Tool 1:   │ │   Tool 2:   │ │    Tool 3:           │
│ Maintenance │ │   Mistakes  │ │ Price Prediction     │
│   (RAG)     │ │    (RAG)     │ │      (ML)            │
└──────┬──────┘ └──────┬───────┘ └──────────┬───────────┘
       │               │                    │
       ▼               ▼                    ▼
┌─────────────┐ ┌─────────────┐ ┌──────────────────────┐
│  Pinecone   │ │  Pinecone   │ │  ML Model (pickle)   │
│  Index 1    │ │  Index 2    │ │  HistGradientBoost   │
└─────────────┘ └─────────────┘ └──────────────────────┘
```

## 📓 Project Notebooks

The project consists of **two main notebooks** that must be executed in order:

### 1. `entrenamiento/entrenamiento_del_modelo.ipynb`

**Purpose**: Train the Machine Learning model to predict property prices.

**Features**:

- Exploratory data analysis (EDA)
- Data cleaning and transformation
- Logarithmic transformation of target price
- One-Hot Encoding for categorical variables
- Model selection using Grid Search
- Training of `HistGradientBoostingRegressor` model
- Export of trained model as `modelo_inmobiliario.pkl`

**Input**: Dataset `data_de_entrenamiento/meli_limpio.Rdata` (2018 data)

- Original dataset: [Real Estate Offers in Montevideo, Uruguay](https://www.kaggle.com/datasets/ppicardo/real-estate-offers-in-montevideo-uruguay) on Kaggle

**Output**: `modelo_de_prediccion/modelo_inmobiliario.pkl`

### 2. `agente/Agente.ipynb`

**Purpose**: Create and run the conversational agent with all its capabilities.

**Features**:

- Load trained ML model
- Process and chunk PDF documents
- Generate embeddings and load into Pinecone
- Configure LangGraph agent with three tools:
  - `recomendacion_buen_uso_vivienda`: Maintenance queries
  - `errores_al_vender_propiedad`: Common mistakes queries
  - `predecir_precio_venta_propiedad`: Price prediction
- Integrated Gradio interface to interact with the agent

**Inputs**:

- `modelo_de_prediccion/modelo_inmobiliario.pkl` (generated by training notebook)
- `documentos/guia para el buen uso de la vivienda_para web.pdf`
- `documentos/erroresAlVenderTuPropiedad.pdf`

**Output**: Interactive web interface with the agent

## ⚙️ Configuration and Requirements

### Prerequisites

- Google account (to use Google Colab)
- [Pinecone](https://www.pinecone.io/) account (free plan available)
- [HuggingFace](https://huggingface.co/) token (free)

### Environment Variables Configuration

Both notebooks require configuring the following environment variables in the corresponding cells:

```python
import os

# Pinecone API Key (get it at https://www.pinecone.io/)
os.environ["PINECONE_API_KEY"] = "your-api-key-here"

# HuggingFace Token (get it at https://huggingface.co/settings/tokens)
os.environ["HF_TOKEN"] = "your-token-here"
```

### Pinecone Configuration

1. Create an account at [Pinecone](https://www.pinecone.io/)
2. Create two vector indexes:
   - **Index 1**: `guia-mantenimiento`
     - Dimensions: 384
     - Metric: cosine
   - **Index 2**: `errores-venta-propiedad`
     - Dimensions: 384
     - Metric: cosine

**Note**: Indexes are automatically created in the `Agente.ipynb` notebook if they don't exist, or you can create them manually from the Pinecone dashboard.

## 💻 How to Use the Project

### Complete Workflow

#### Step 1: Train the Model

1. Open `entrenamiento/entrenamiento_del_modelo.ipynb` in Google Colab
2. Upload the file `data_de_entrenamiento/meli_limpio.Rdata` to the Colab environment
3. Run all cells in the notebook
4. The notebook will generate `modelo_inmobiliario.pkl` which must be downloaded and saved

#### Step 2: Configure and Run the Agent

1. Open `agente/Agente.ipynb` in Google Colab
2. Upload the following files to the project root in Colab:
   - `modelo_de_prediccion/modelo_inmobiliario.pkl` (generated in Step 1)
   - `documentos/guia para el buen uso de la vivienda_para web.pdf`
   - `documentos/erroresAlVenderTuPropiedad.pdf`
3. Configure environment variables (PINECONE_API_KEY and HF_TOKEN) in the corresponding cells
4. Run all cells in the notebook
5. The notebook will load documents into Pinecone (if first time) and then start the Gradio interface

### Using the Agent

Once the `Agente.ipynb` notebook is executed, you'll have access to a Gradio interface with two modes:

#### Conversational Chat Mode

You can ask questions in natural language such as:

- "I want to sell my apartment in Pocitos, what mistakes should I avoid?"
- "How do I maintain an old house in good condition?"
- "I have a house in La Teja, 2 bedrooms and 1 bathroom, what price could it have?"

The agent will automatically select the appropriate tool based on your query.

#### Price Estimation Form Mode

You can complete a form with your property characteristics to get a price estimate directly from the ML model.

### Model Prediction Parameters

The model accepts the following features to predict price:

**Required Features:**

- `tipoInmueble`: "Apartamentos" or "Casas"
- `barrio`: Neighborhood name in Montevideo
- `condicion`: "new" or "used"
- `departamento`: "Montevideo"

**Optional Features:**

- `dormitorios`: Number of bedrooms (0-6)
- `banos`: Number of bathrooms (0-4)
- `supTot`: Total area in m²
- `supConstru`: Built area in m²
- `antiguedad`: Years of age
- `ambientes`: Number of rooms
- `expensas`: Maintenance fees amount
- `apPpiso`: Apartment per floor
- `ascensores`: Number of elevators

**Boolean Features** (Yes/No):

- `terraza`, `patio`, `toilette`, `aircond`, `calefacc`, `jardin`, `piscina`, `garage`, `kitchenette`, `losaRad`, `parrillero`, `salaReuniones`, `seguridad`, `amoblado`, `comedor`

**Categorical Features:**

- `tipoEdif`: Building type
- `estado`: "A reciclar", "Regular", "Bueno", "Muy bueno", "Excelente"
- `orientacion`: "Frente", "Contrafrente", "Lateral"

## 📁 Project Structure

```
real-estate-agent/
│
├── agente/
│   └── Agente.ipynb                    # Main agent notebook (Colab)
│
├── entrenamiento/
│   └── entrenamiento_del_modelo.ipynb # Notebook to train ML model
│
├── modelo_de_prediccion/
│   └── modelo_inmobiliario.pkl        # Trained model (generated by entrenamiento_del_modelo.ipynb)
│
├── documentos/
│   ├── guia para el buen uso de la vivienda_para web.pdf
│   └── erroresAlVenderTuPropiedad.pdf
│
├── data_de_entrenamiento/
│   └── meli_limpio.Rdata               # Training dataset (2018)
│
├── README.md                            # This file
```

## 📊 Results and Metrics

### Price Prediction Model Performance

- **Performance Metric**: 64% better than reference median
- **Algorithm**: HistGradientBoostingRegressor
- **Training Dataset**: Real estate market data from Montevideo (2018)
- **Applied Transformations**:
  - Logarithmic transformation on target price
  - One-Hot Encoding for categorical variables
  - Normalization of numerical variables
- **Optimization**: Grid Search for hyperparameter selection

### Agent Capabilities

✅ **Contextual Responses**: The agent maintains conversation context  
✅ **Intelligent Tool Selection**: Automatically identifies which tool to use based on query  
✅ **Hallucination Prevention**: Only responds based on verified information  
✅ **Semantic Search**: Finds relevant information even with natural language queries

### Known Limitations

⚠️ **2018 Data**: Predicted prices correspond to the 2018 market and may not reflect current values  
⚠️ **Geographic Coverage**: The model is specifically trained for Montevideo, Uruguay  
⚠️ **Data Quality**: The original dataset contained duplicate and inconsistent data that affects accuracy  
⚠️ **Colab Execution**: The project is designed to run on Google Colab, not as a standalone application

## 🔮 Future Improvements

### Short Term

- [ ] Update model with more recent real estate market data
- [ ] Implement caching system for frequent responses
- [ ] Add more robust input validation

### Technical Considerations

- Improve quality and cleaning of training dataset
- Explore more advanced model architectures (XGBoost, LightGBM, Neural Networks)
- Implement A/B testing system for different models
- Optimize infrastructure costs (Pinecone, HuggingFace)

---

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👤 Author

**Lucas Tejería**

Developed as a demonstration project showcasing the integration of Machine Learning, RAG, and conversational AI for real estate advisory applications.

## 🙏 Acknowledgments

- **[Real Estate Offers in Montevideo, Uruguay](https://www.kaggle.com/datasets/ppicardo/real-estate-offers-in-montevideo-uruguay)** - Dataset de Kaggle utilizado para entrenar el modelo de predicción de precios
- **Ministry of Housing and Territorial Planning** (Uruguay) for the housing maintenance guide
- **www.onceonce.uy** for the property selling mistakes documentation
- The open-source community for the excellent tools and libraries used in this project

---

**Note**: This project is designed to demonstrate the workflow and architecture for building an intelligent real estate advisory system. The focus is on the technical implementation rather than absolute model accuracy. The project runs on Google Colab using Jupyter notebooks.
