import numpy as np
import parselmouth
import socket
#import time
#print(parselmouth.__version__)

"""
The if __name__ == '__main__': block in Python 
is used to ensure that the code inside it only runs when the script is executed as 
the main module, and not when it is imported as a module into another script.
"""
def check_message(message):
    if message == 'getNhrMethod':
        response = getNHRValue()
        return str(response)
    elif message =="brainMri":
        return "Shit isnt here babes"
    else:
        return ""

def predictVoiceHealth():
    return ""
def getNHRValue():

    audioExtracted = parselmouth.Sound("w2c.wav")

    intensity = audioExtracted.to_intensity()

    # intensity_value = intensity.get_value(0, parselmouth.ValueInterpolation.CUBIC)

    intensity_value = []

    extractedAudioPointLength=audioExtracted.xmax
    for count in range(int(extractedAudioPointLength)):
        intensity_value.append(intensity.get_value(count, parselmouth.ValueInterpolation.CUBIC))#Get intensity values

    intensity_average = (np.nansum(intensity_value) / audioExtracted.xmax)

    harmonicity = audioExtracted.to_harmonicity()

    harmonicity_value = []

    extractedAudioPointLength=audioExtracted.xmax
    for count in range(int(extractedAudioPointLength)):
        harmonicity_value.append(harmonicity.get_value(count, parselmouth.ValueInterpolation.CUBIC))


    harmonocity_value_avg = (np.nansum(harmonicity_value) / audioExtracted.xmax)


    NHR = intensity_average / harmonocity_value_avg  # calculate NHR value

    return NHR

if __name__ == '__main__':
    server = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server.bind(('localhost', 8600))
    server.listen(1)

    while True:
        connection, address =server.accept()
        message = connection.recv(1024).decode()
        response = check_message(message)
        connection.send(response.encode())
        print("response", response)
        connection.close()





